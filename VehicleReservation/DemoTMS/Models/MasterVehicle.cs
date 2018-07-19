using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTMS.Models
{
    public class MasterVehicle
    {
        [Key]
        public int Id { get; set; }
        [StringLength(25)]
        public string VehicleBrand { get; set; }
        public int? Capacity { get; set; }

    }
}
