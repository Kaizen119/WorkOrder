using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server.Services.TechnicianService{
    public interface ITechnicianService{

        Task<ServiceResponse<List<GetTechnicianResponseDto>>> GetAllTechnicians();
        Task<ServiceResponse<GetTechnicianResponseDto>> GetTechnicianById(int id);
        Task<ServiceResponse<List<GetTechnicianResponseDto>>> AddTechnician(AddTechnicianRequestDto newTechnician);
        Task<ServiceResponse<GetTechnicianResponseDto>> UpdateTechnician(UpdateTechnicianRequestDto updatedTechnician);
        Task<ServiceResponse<List<GetTechnicianResponseDto>>> DeleteTechnician(int id);
    }
}