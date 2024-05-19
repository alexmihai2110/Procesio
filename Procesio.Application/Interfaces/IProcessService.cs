using Procesio.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Application.Interfaces
{
    public interface IProcessService
    {
        Task<IEnumerable<ProcessDTO>> GetProcesses();
        Task<ProcessDTO> GetProcess(Guid id);
        Task<bool> DeleteProcess(Guid id);
        Task CreateProcess(ProcessDTO processDTO);
        Task UpdateProcess(ProcessDTO processDTO);
        Task CheckProcess(Guid id);
    }
}
