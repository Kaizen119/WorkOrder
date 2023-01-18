using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.Services.WorkOrderService{

    public class WorkOrderService : IWorkOrderService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

//pulling in context and mapper
        public WorkOrderService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

//logic for adding a work order to the DB 

    public async Task<ServiceResponse<List<GetWorkOrderResponseDto>>> AddWorkOrder(AddWorkOrderRequestDto newWorkOrder)
        {
            var serviceResponse = new ServiceResponse<List<GetWorkOrderResponseDto>>();
            var workOrder = _mapper.Map<WorkOrder>(newWorkOrder);
            _context.WorkOrders.Add(workOrder);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.WorkOrders.Select(wo => _mapper.Map<GetWorkOrderResponseDto>(wo)).ToListAsync();
        return serviceResponse;
        }
    //     public async Task<ServiceResponse<List<GetWorkOrderResponseDto>>> AddWorkOrder(AddWorkOrderRequestDto newWorkOrder)
    // {
    //     var serviceResponse = new ServiceResponse<List<GetWorkOrderResponseDto>>();
    //     var workOrder = _mapper.Map<WorkOrder>(newWorkOrder);
    //     var technician = await _context.Technicians.FindAsync(newWorkOrder.TechnicianId);
    //     workOrder.Class = technician;
    //     _context.WorkOrders.Add(workOrder);
    //     await _context.SaveChangesAsync();
    //     serviceResponse.Data = await _context.WorkOrders.Select(wo => _mapper.Map<GetWorkOrderResponseDto>(wo)).ToListAsync();
    //     return serviceResponse;
    // }

//logic to remove a workorder from the DB
        public async Task<ServiceResponse<List<GetWorkOrderResponseDto>>> DeleteWorkOrder(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetWorkOrderResponseDto>>();
            try{
            var workOrder = await _context.WorkOrders.FirstOrDefaultAsync(wo => wo.WONum == id);
            if(workOrder is null)
                throw new Exception($"Work Order with Work Order Number '{id}' not found.");
            
            _context.WorkOrders.Remove(workOrder);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.WorkOrders.Select(wo => _mapper.Map<GetWorkOrderResponseDto>(wo)).ToListAsync();

            }catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            Console.WriteLine(serviceResponse);
            return serviceResponse;

        }

//logic to fetch all work orders from the DB
        public async Task<ServiceResponse<List<GetWorkOrderResponseDto>>> GetAllWorkOrders()
        {
            var serviceResponse = new ServiceResponse<List<GetWorkOrderResponseDto>>();
            var dbWorkOrders = await _context.WorkOrders.ToListAsync();
            serviceResponse.Data = dbWorkOrders.Select(wo => _mapper.Map<GetWorkOrderResponseDto>(wo)).ToList();
            return serviceResponse;
        }

//logic to fetch one work order by id from the DB
        public async Task<ServiceResponse<GetWorkOrderResponseDto>> GetWorkOrderById(int id)
        {
            var serviceResponse = new ServiceResponse<GetWorkOrderResponseDto>();

            var dbWorkOrder = await _context.WorkOrders.FirstOrDefaultAsync(wo => wo.WONum == id);
            serviceResponse.Data =  _mapper.Map<GetWorkOrderResponseDto>(dbWorkOrder);
            return serviceResponse;

        }

//logic to fetch one work order by status from the DB 
        public async Task<IEnumerable<WorkOrder>> GetWorkOrderByStatus(string status)
    {
        return await _context.WorkOrders.Where(wo => wo.Status == status).ToListAsync();
    }

//logic to update one work order in the DB
        public async Task<ServiceResponse<GetWorkOrderResponseDto>> UpdateWorkOrder(UpdateWorkOrderRequestDto updatedWorkOrder)
        {
            var serviceResponse = new ServiceResponse<GetWorkOrderResponseDto>();
            try{
            var workOrder = await _context.WorkOrders.FirstOrDefaultAsync(wo => wo.WONum == updatedWorkOrder.WONum);
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
            workOrder.Problem = updatedWorkOrder.Problem;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetWorkOrderResponseDto>(workOrder);

            }catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
    }
}