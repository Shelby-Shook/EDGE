using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDGE.Data
{
    public class WorkoutLog
    {
        [Key]
        public int Id {get; set;} 
        public DateTime Date { get; set; }
        public string? Notes {get; set;}

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
    }
}