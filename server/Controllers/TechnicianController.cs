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

// for fetching all techs from the db
    [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTechnicianResponseDto>>>> Get(){
            return Ok(await _technicianService.GetAllTechnicians());
        }

// for fetching one tech by id from the DB
    [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTechnicianResponseDto>>> GetSingle(int id){
            return Ok(await _technicianService.GetTechnicianById(id));
        }

// for adding a new Technician to the DB
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetTechnicianResponseDto>>>> AddTechnician(AddTechnicianRequestDto newTechnician){
        return Ok(await _technicianService.AddTechnician(newTechnician));
    }

//for updating tech
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetTechnicianResponseDto>>>> UpdateTechnician(UpdateTechnicianRequestDto updatedTechnician){
        var response = await _technicianService.UpdateTechnician(updatedTechnician);
        if (response.Data is null){
            return NotFound(response);
        }
        return Ok(response);
    }

// Delete for tech by Id
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