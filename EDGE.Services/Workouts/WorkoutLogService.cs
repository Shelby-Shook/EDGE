using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDGE.Data;
using EDGE.Models.WorkoutLog;
using Microsoft.EntityFrameworkCore;

namespace EDGE.Services.Workouts
{
    public class WorkoutLogService : IWorkoutLogService
    {
        private readonly EdgeDbContext _db;
        public WorkoutLogService(EdgeDbContext db) 
        { 
            _db = db;
        }
        public async Task<bool> CreateWorkoutLog(WorkoutLogCreate model)
        {
            var entity = new WorkoutLog
            {   UserId = 0,
                Name = model.Name,
                Notes = model.Notes,
                Date = DateTime.Today
            };
                _db.WorkoutLog.Add(entity);
            var numberChanges = await _db.SaveChangesAsync();
            return numberChanges == 1;
        }
        public async Task<IEnumerable<WorkoutLogDetail>>GetAllWorkoutLogs()
        {
            var entities = await _db.WorkoutLog.Select(w=> new WorkoutLogDetail
            {
                Notes = w.Notes, 
                Date = w.Date
            }).ToListAsync();

            return entities;
        }

        public async Task<WorkoutLogDetail>GetWorkoutLogByIDAsync(int id)
        {
            WorkoutLog? entity = await _db.WorkoutLog.FirstOrDefaultAsync(w=> w.Id==id);
            WorkoutLogDetail model = new WorkoutLogDetail
            {
                Notes = entity.Notes, 
                Date = entity.Date
            };
            return model;
        }

        public async Task<IEnumerable<WorkoutLogDetail>>GetWorkoutsByDateAsync(DateTime date)
        {
            var entity = await _db.WorkoutLog.Where(w=> w.Date==date).Select(w=>
            new WorkoutLogDetail
            {
                Notes = w.Notes,
                Date = w.Date
            }).ToListAsync();
            return entity;
        }
        
    }
}