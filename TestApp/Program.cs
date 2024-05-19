using System;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var hostname = "localhost:5000"; 
            var queueName = "check-process"; 

            using (RabbitMQSubscriber subscriber = new RabbitMQSubscriber(hostname, queueName))
            {
                await subscriber.Subscribe();
            }
        }
    }
}
