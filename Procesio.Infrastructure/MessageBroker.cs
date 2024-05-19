using Newtonsoft.Json;
using Procesio.Core.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Infrastructure
{
    public class RabbitMQMessageBroker : IMessageBroker, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQMessageBroker(string hostname)
        {
            var factory = new ConnectionFactory() { HostName = hostname };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public async Task Publish<T>(string queueName, T message)
        {
            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            await Task.Run(() =>
            {
                _channel.BasicPublish(exchange: "",
                                  routingKey: queueName,
                                  basicProperties: null,
                                  body: messageBody);
            });
        }

        public async Task Subscribe<T>(string queueName, Action<T> onMessageReceived)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var deserializedMessage = JsonConvert.DeserializeObject<T>(message);
                onMessageReceived(deserializedMessage);
            };
            await Task.Run(() =>
            {
                _channel.BasicConsume(queue: queueName,
                                  autoAck: true,
                                  consumer: consumer);
            });
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }
    }
}
