using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDGE.Data
{
    public class Users
    {
        [Key]
        public int Id {get; set;}

        [Required]
        public string? Name {get; set;}

        [Required]
        public string? Email {get; set;}
    }
}