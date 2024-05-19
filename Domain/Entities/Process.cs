using Procesio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Core.Entities
{
    public class Process
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProcessType ProcessType { get; set; }
        public bool IsChecked { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
