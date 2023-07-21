using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDGE.Models.WorkoutLog
{
    public class WorkoutLogCreate
    {
         public DateTime Date { get; set; }
        public string? Notes { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }
    }
}