using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server.Services.WorkOrderService{
    public interface IWorkOrderService{

        Task<ServiceResponse<List<GetWorkOrderResponseDto>>> GetAllWorkOrders();
        Task<ServiceResponse<GetWorkOrderResponseDto>> GetWorkOrderById(int id);
        Task<ServiceResponse<List<GetWorkOrderResponseDto>>> AddWorkOrder(AddWorkOrderRequestDto newWorkOrder);
        Task<ServiceResponse<GetWorkOrderResponseDto>> UpdateWorkOrder(UpdateWorkOrderRequestDto updatedWorkOrder);
    }
}