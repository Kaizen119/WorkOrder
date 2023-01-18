using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server{
    public class AutoMapperProfile : Profile{

//all maps for the methods to dtos
        public AutoMapperProfile()
        {
            CreateMap<WorkOrder,GetWorkOrderResponseDto>();
            CreateMap<AddWorkOrderRequestDto,WorkOrder>();
            CreateMap<UpdateWorkOrderRequestDto, WorkOrder>();
            CreateMap<Technician,GetTechnicianResponseDto>();
            CreateMap<AddTechnicianRequestDto,Technician>();
            CreateMap<UpdateTechnicianRequestDto, Technician>();
            CreateMap<Technician,GetTechnicianResponseDto>();
        }
    }
}