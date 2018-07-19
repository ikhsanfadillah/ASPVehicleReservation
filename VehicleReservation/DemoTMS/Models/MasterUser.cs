using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTMS.Models
{
    public class MasterUser
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(75)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

    }
}
