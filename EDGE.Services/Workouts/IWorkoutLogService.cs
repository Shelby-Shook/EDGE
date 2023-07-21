using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDGE.Models.WorkoutLog;

namespace EDGE.Services.Workouts
{
    public interface IWorkoutLogService
    {
        Task<WorkoutLogDetail>GetWorkoutLogByIDAsync(int id);
        Task<IEnumerable<WorkoutLogDetail>>GetWorkoutsByDateAsync(DateTime date);

        Task<IEnumerable<WorkoutLogDetail>>GetAllWorkoutLogs();
        Task<bool> CreateWorkoutLog(WorkoutLogCreate model);
    }
}