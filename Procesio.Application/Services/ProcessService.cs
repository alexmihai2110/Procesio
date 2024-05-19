using Procesio.Application.DTOs;
using Procesio.Application.Interfaces;
using Procesio.Core.Entities;
using Procesio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Application.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _processRepository;
        private readonly IMessageBroker _messageBroker;
        public ProcessService(IProcessRepository processRepository, IMessageBroker messageBroker)
        {
            _processRepository = processRepository;
            _messageBroker = messageBroker;
        }

        public async Task CheckProcess(Guid id)
        {
            await _messageBroker.Publish("check-process", id);
        }

        public async Task CreateProcess(ProcessDTO processDTO)
        {
            //mapper autoMapper TBD
            var process = new Process
            {
                Id = processDTO.Id,
                CreatedAt = DateTime.Now,
                Name = processDTO.Name,
                ProcessType = processDTO.ProcessType
            };
            await _processRepository.Add(process);
        }

        public async Task<bool> DeleteProcess(Guid id)
        {
            return await _processRepository.Delete(id) != null;
        }

        public async Task<ProcessDTO> GetProcess(Guid id)
        {
            var process = await _processRepository.GetById(id);

            //mapper autoMapper TBD
            return new ProcessDTO
            {
                ProcessType = process.ProcessType,
                Name = process.Name,
                Id = process.Id
            };
        }

        public async Task<IEnumerable<ProcessDTO>> GetProcesses()
        {
            var processEntities = await _processRepository.GetAll();

            //mapper autoMapper TBD
            return processEntities.Select(pe => new ProcessDTO
            {
                ProcessType = pe.ProcessType,
                Id = pe.Id,
                Name = pe.Name
            });
        }

        public async Task UpdateProcess(ProcessDTO processDTO)
        {
            var process = await _processRepository.GetById(processDTO.Id);
            if (process != null)
            {
                process.Name = processDTO.Name;
                process.ProcessType = processDTO.ProcessType;
                await _processRepository.Update(process);
            }
        }
    }
}
