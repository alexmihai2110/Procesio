using Procesio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class ProcessFactory
    {
        public static IProcess CreateProcess(ProcessType processType)
        {
            return processType switch
            {
                ProcessType.DataGenerator => new ProcessData(),
                ProcessType.ExcelGenerator => new ProcessExcel(),
                ProcessType.SAP => new ProcessSAP(),
                _ => throw new ArgumentException("Invalid process type", nameof(processType)),
            };
        }
    }
}
