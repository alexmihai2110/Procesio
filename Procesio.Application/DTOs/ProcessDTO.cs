using Procesio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Application.DTOs
{
    public class ProcessDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProcessType ProcessType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
