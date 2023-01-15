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

    [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetWorkOrderResponseDto>>>> Get(){
            return Ok(await _workOrderService.GetAllWorkOrders());
        }

    [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetWorkOrderResponseDto>>> GetSingle(int id){
            return Ok(await _workOrderService.GetWorkOrderById(id));
        }
        
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetWorkOrderResponseDto>>>> AddWorkOrder(AddWorkOrderRequestDto newWorkOrder){
        return Ok(await _workOrderService.AddWorkOrder(newWorkOrder));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetWorkOrderResponseDto>>>> UpdateWorkOrder(UpdateWorkOrderRequestDto updatedWorkOrder){
        var response = await _workOrderService.UpdateWorkOrder(updatedWorkOrder);
        if (response.Data is null){
            return NotFound(response);
        }
        return Ok(response);
    }
    }
}