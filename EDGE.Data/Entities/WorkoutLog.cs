using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDGE.Data.Entities
{
    public class WorkoutLog
    {
        [Key]
        public int Id {get; set;} 
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
        public string Name { get; set; } = string.Empty!;

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual UserEntity User {get; set;}
    }
}