using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server.Services.WorkOrderService{

    public class WorkOrderService : IWorkOrderService
    {
        private static List<WorkOrder> workOrders = new List<WorkOrder>{
            new WorkOrder(),
            new WorkOrder{
                WONum = 1,
                Email = "iamtheknight@gmail.com",
                Status = "Open",
                DateReceived = DateTime.Now,
                DateAssigned = null,
                DateComplete = null,
                ContactName = "Bruce",
                TechnicianId = 2,
                Problem = "The bat computer is broken"
            },
            new WorkOrder{
                WONum = 2,
                Email = "supes@gmail.com",
                Status = "Open",
                DateReceived = DateTime.Now,
                DateAssigned = null,
                DateComplete = null,
                ContactName = "Clark",
                TechnicianId = 3,
                Problem = "I cant get into the fortress of solitude"
            }
        };


        private readonly IMapper _mapper;
        public WorkOrderService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetWorkOrderResponseDto>>> AddWorkOrder(AddWorkOrderRequestDto newWorkOrder)
        {
            var serviceResponse = new ServiceResponse<List<GetWorkOrderResponseDto>>();
            var workOrder = _mapper.Map<WorkOrder>(newWorkOrder);
            workOrder.WONum = workOrders.Max(wo => wo.WONum) +1;
            workOrders.Add(workOrder);
            serviceResponse.Data = workOrders.Select(wo => _mapper.Map<GetWorkOrderResponseDto>(wo)).ToList();
        return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetWorkOrderResponseDto>>> GetAllWorkOrders()
        {
            var serviceResponse = new ServiceResponse<List<GetWorkOrderResponseDto>>();
            serviceResponse.Data = workOrders.Select(wo => _mapper.Map<GetWorkOrderResponseDto>(wo)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetWorkOrderResponseDto>> GetWorkOrderById(int id)
        {
            var serviceResponse = new ServiceResponse<GetWorkOrderResponseDto>();

            var workOrder = workOrders.FirstOrDefault(wo => wo.WONum == id);
            serviceResponse.Data =  _mapper.Map<GetWorkOrderResponseDto>(workOrder);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetWorkOrderResponseDto>> UpdateWorkOrder(UpdateWorkOrderRequestDto updatedWorkOrder)
        {
            var serviceResponse = new ServiceResponse<GetWorkOrderResponseDto>();
            try{
            var workOrder = workOrders.FirstOrDefault(wo => wo.WONum == updatedWorkOrder.WONum);
            if(workOrder is null)
                throw new Exception($"Work Order with Work Order Number '{updatedWorkOrder.WONum}' not found.");
            _mapper.Map(updatedWorkOrder, workOrder);

            workOrder.Email = updatedWorkOrder.Email;
            workOrder.Status = updatedWorkOrder.Status;
            workOrder.DateReceived = updatedWorkOrder.DateReceived;
            workOrder.DateAssigned = updatedWorkOrder.DateAssigned;
            workOrder.DateComplete = updatedWorkOrder.DateComplete;
            workOrder.ContactName = updatedWorkOrder.ContactName;
            workOrder.TechnicianComments = updatedWorkOrder.TechnicianComments;
            workOrder.ContactNumber = updatedWorkOrder.ContactNumber;
            workOrder.TechnicianId = updatedWorkOrder.TechnicianId;
            workOrder.Problem = updatedWorkOrder.Problem;

            serviceResponse.Data = _mapper.Map<GetWorkOrderResponseDto>(workOrder);

            }catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
    }
}