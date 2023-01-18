using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class Technician{
    
    public int TechnicianID { get; set; }
    public string TechnicianName { get; set; } = "required";
    public string TechnicianEmail { get; set; } = "required";
    public List<WorkOrder>? WorkOrders { get; set; }
}

//model for creating a new tech 