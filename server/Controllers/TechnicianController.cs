using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace server.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnicianController : ControllerBase{
        
        private readonly ITechnicianService _technicianService;

        public TechnicianController(ITechnicianService technicianService)
    {
            _technicianService = technicianService;
        }

    [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTechnicianResponseDto>>>> Get(){
            return Ok(await _technicianService.GetAllTechnicians());
        }

    [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTechnicianResponseDto>>> GetSingle(int id){
            return Ok(await _technicianService.GetTechnicianById(id));
        }
        
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetTechnicianResponseDto>>>> AddTechnician(AddTechnicianRequestDto newTechnician){
        return Ok(await _technicianService.AddTechnician(newTechnician));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetTechnicianResponseDto>>>> UpdateTechnician(UpdateTechnicianRequestDto updatedTechnician){
        var response = await _technicianService.UpdateTechnician(updatedTechnician);
        if (response.Data is null){
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTechnicianResponseDto>>> DeleteTechnician(int id){
            var response = await _technicianService.DeleteTechnician(id);
        if (response.Data is null){
            return NotFound(response);
        }
        return Ok(response);
        }
    }
}