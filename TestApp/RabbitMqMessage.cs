using Procesio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class RabbitMqMessage
    {
        public Guid Id { get; set; }
        public ProcessType ProcessType { get;set; }
    }
}
