using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Core.Interfaces
{
    public interface IMessageBroker
    {
        Task Publish<T>(string queueName, T message);
        Task Subscribe<T>(string queueName, Action<T> onMessageReceived);
    }
}
