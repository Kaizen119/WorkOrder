using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace server.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkOrderController : ControllerBase{
        
        private readonly IWorkOrderService _workOrderService;

        public WorkOrderController(IWorkOrderService workOrderService)
    {
            _workOrderService = workOrderService;
        }

// for fetching all workorders from the Db 
    [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetWorkOrderResponseDto>>>> Get(){
            return Ok(await _workOrderService.GetAllWorkOrders());
        }
    
// for fetching work orders by status from the DB 
    [HttpGet("GetAll/{status}")]
    public async Task<IActionResult> GetWorkOrdersByStatus(string status)
    {
        var workOrders = await _workOrderService.GetWorkOrderByStatus(status);
        if (workOrders == null)
        {
            return NotFound();
        }
        return Ok(workOrders);
    }

// for fetching one work order by id from the DB 
    [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetWorkOrderResponseDto>>> GetSingle(int id){
            return Ok(await _workOrderService.GetWorkOrderById(id));
        }
        
// for creating a new WorkOrder order in the DB 
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetWorkOrderResponseDto>>>> AddWorkOrder(AddWorkOrderRequestDto newWorkOrder){
        return Ok(await _workOrderService.AddWorkOrder(newWorkOrder));
    }

// for updating one workorder by id in the DB 
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetWorkOrderResponseDto>>>> UpdateWorkOrder(UpdateWorkOrderRequestDto updatedWorkOrder){
        var response = await _workOrderService.UpdateWorkOrder(updatedWorkOrder);
        if (response.Data is null){
            return NotFound(response);
        }
        return Ok(response);
    }

// for deleting one workorder from the DB
    [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetWorkOrderResponseDto>>> DeleteWorkOrder(int id){
            var response = await _workOrderService.DeleteWorkOrder(id);
        if (response.Data is null){
            return NotFound(response);
        }
        return Ok(response);
        }
    }
}