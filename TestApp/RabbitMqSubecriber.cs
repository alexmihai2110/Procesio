using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestApp
{
    public class RabbitMQSubscriber :IDisposable
    {
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQSubscriber(string hostname, string queueName)
        {
            _hostname = hostname;
            _queueName = queueName;

            var factory = new ConnectionFactory() { HostName = _hostname };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public async Task Subscribe()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await HandleMessageAsync(message);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(queue: _queueName,
                                 autoAck: false,
                                 consumer: consumer);

            Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");
        }

        private Task HandleMessageAsync(string message)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($" [x] Received {message}");
                var deserializedMessage = JsonSerializer.Deserialize<RabbitMqMessage>(message);
                IProcess process = ProcessFactory.CreateProcess(deserializedMessage.ProcessType);
                process.Execute();
            });
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
