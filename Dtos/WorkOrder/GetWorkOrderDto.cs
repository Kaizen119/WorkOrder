using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.WorkOrder{
    public class GetWorkOrderResponseDto{
        public int WONum { get; set; }
        public string? Email { get; set; }  
        public string? Status { get; set; }
        public DateTime? DateReceived { get; set; } = DateTime.Now ;
        public DateTime? DateAssigned { get; set; }
        public DateTime? DateComplete { get; set; }
        public string? ContactName { get; set; }
        public string? TechnicianComments { get; set; }
        public string? ContactNumber { get; set; }
        public string? Problem { get; set; }
        public int? TechnicianID { get; set; }
    }
}

