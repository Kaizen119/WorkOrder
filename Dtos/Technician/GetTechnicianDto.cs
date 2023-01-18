using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos.Technician{
    public class GetTechnicianResponseDto{
    public int TechnicianID { get; set; }
    public string TechnicianName { get; set; } = "required";
    public string TechnicianEmail { get; set; } = "required";
    }
}

// DTOs to separate domain objects from the presentation layer.