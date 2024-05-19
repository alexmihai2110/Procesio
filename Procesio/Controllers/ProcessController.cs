using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Procesio.Application.DTOs;
using Procesio.Application.Interfaces;
using Procesio.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procesio.Controllers
{
    [ApiController]
    [Route("/process")]
    public class ProcessController : ControllerBase
    {

        private readonly ILogger<ProcessController> _logger;
        private readonly IProcessService _processService;

        public ProcessController(ILogger<ProcessController> logger, IProcessService processService)
        {
            _logger = logger;
            _processService = processService;
        }
        
        //fluentValidation TBD

        [HttpGet("/get")]
        public async Task<IEnumerable<ProcessDTO>> GetProcesses()
        {
            return await _processService.GetProcesses();
        }

        [HttpGet("/get/{id}")]
        public async Task<ProcessDTO> Get([FromQuery] Guid id)
        {
            return await _processService.GetProcess(id);
        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var deleted = await _processService.DeleteProcess(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create([FromBody] ProcessDTO process)
        {
            await _processService.CreateProcess(process);
            return Ok();
        }

        [HttpPut("/update/{id}")]
        public async Task<IActionResult> Update([FromBody] ProcessDTO process)
        {
            await _processService.UpdateProcess(process);
            return Ok();
        }

        [HttpPost("/check/{id}")]
        public async Task<IActionResult> CheckProcess([FromQuery] Guid id)
        {
            await _processService.CheckProcess(id);
            return Ok();
        }

    }
}
