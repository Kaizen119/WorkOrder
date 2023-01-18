
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models{
    
    public class WorkOrder{
        [Key]
        public int WONum { get; set; }

        public string? Email { get; set; }  
        public string? Status { get; set; } = "Open";
        public DateTime? DateReceived { get; set; } = DateTime.Now ; //date time updates on submission
        public DateTime? DateAssigned { get; set; }
        public DateTime? DateComplete { get; set; }
        public string? ContactName { get; set; }
        public string? TechnicianComments { get; set; }
        public string? ContactNumber { get; set; }
        public string? Problem { get; set; }
        public Technician? Technician { get; set; }
        public int? TechnicianID { get; set; }
    }
}

//model for creating a new work order