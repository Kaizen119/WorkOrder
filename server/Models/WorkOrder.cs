
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models{
    public class WorkOrder{
        public int WONum { get; set; }
        public string? Email { get; set; }  
        public string? Status { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime? DateComplete { get; set; }
        public string? ContactName { get; set; }
        public string? TechnicianComments { get; set; }
        public string? ContactNumber { get; set; }
        public int? TechnicianId { get; set; }
        public string? Problem { get; set; }
    }
}