using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.Services.TechnicianService{

    public class TechnicianService : ITechnicianService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;
        public TechnicianService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetTechnicianResponseDto>>> AddTechnician(AddTechnicianRequestDto newTechnician)
        {
            var serviceResponse = new ServiceResponse<List<GetTechnicianResponseDto>>();
            var technician = _mapper.Map<Technician>(newTechnician);
            _context.Technicians.Add(technician);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Technicians.Select(wo => _mapper.Map<GetTechnicianResponseDto>(wo)).ToListAsync();
        return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTechnicianResponseDto>>> DeleteTechnician(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTechnicianResponseDto>>();
            try{
            var technician = await _context.Technicians.FirstOrDefaultAsync(t => t.TechnicianID == id);
            if(technician is null)
                throw new Exception($"Technician with Technician Id  '{id}' not found.");
            
            _context.Technicians.Remove(technician);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Technicians.Select(t => _mapper.Map<GetTechnicianResponseDto>(t)).ToListAsync();

            }catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetTechnicianResponseDto>>> GetAllTechnicians()
        {
            var serviceResponse = new ServiceResponse<List<GetTechnicianResponseDto>>();
            var dbTechnicians = await _context.Technicians.ToListAsync();
            serviceResponse.Data = dbTechnicians.Select(t => _mapper.Map<GetTechnicianResponseDto>(t)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTechnicianResponseDto>> GetTechnicianById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTechnicianResponseDto>();

            var dbTechnician = await _context.Technicians.FirstOrDefaultAsync(t => t.TechnicianID == id);
            serviceResponse.Data =  _mapper.Map<GetTechnicianResponseDto>(dbTechnician);
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTechnicianResponseDto>> UpdateTechnician(UpdateTechnicianRequestDto updatedTechnician)
        {
            var serviceResponse = new ServiceResponse<GetTechnicianResponseDto>();
            try{
            var technician = await _context.Technicians.FirstOrDefaultAsync(t => t.TechnicianID== updatedTechnician.TechnicianID);
            if(technician is null)
                throw new Exception($"Technician with Technician ID  '{updatedTechnician.TechnicianID}' not found.");
            _mapper.Map(updatedTechnician, technician);

            technician.TechnicianName  = updatedTechnician.TechnicianName;
            technician.TechnicianEmail = updatedTechnician.TechnicianEmail;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetTechnicianResponseDto>(technician);

            }catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}