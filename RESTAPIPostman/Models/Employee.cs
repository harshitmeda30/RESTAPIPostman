using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIPostman.Models
{
    public class Employee
    {
        
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String name { get; set; }
    }
}
