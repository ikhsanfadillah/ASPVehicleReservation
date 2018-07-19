using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTMS.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Pickup { get; set; }
        [StringLength(100)]
        public string Destination { get; set; }
        public DateTime? PickupDate { get; set; }

        [ForeignKey("MasterUser")]
        public int MasterUserId { get; set; }
        public MasterUser MasterUser { get; set; }
    }
}
