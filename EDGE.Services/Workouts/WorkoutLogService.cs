using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDGE.Data;
using EDGE.Data.Entities;
using EDGE.Models.WorkoutLog;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EDGE.Services.Workouts
{
    public class WorkoutLogService : IWorkoutLogService
    {
        private readonly EdgeDbContext _db;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public WorkoutLogService(EdgeDbContext db, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> CreateWorkoutLog(WorkoutLogCreate model)
        {
            var entity = new WorkoutLog
            {
                UserId = int.Parse(_userManager.GetUserId(_signInManager.Context.User) ?? "0"),
                Name = model.Name,
                Notes = model.Notes,
                Date = DateTime.Today
            };
            _db.WorkoutLog.Add(entity);
            var numberChanges = await _db.SaveChangesAsync();
            return numberChanges == 1;
        }
        public async Task<IEnumerable<WorkoutLogDetail>> GetAllWorkoutLogs()
        {
            var entities = await _db.WorkoutLog.Select(w => new WorkoutLogDetail
            {
                Notes = w.Notes,
                Date = w.Date
            }).ToListAsync();

            return entities;
        }

        public async Task<WorkoutLogDetail> GetWorkoutLogByIDAsync(int id)
        {
            WorkoutLog? entity = await _db.WorkoutLog.FirstOrDefaultAsync(w => w.Id == id);
            WorkoutLogDetail model = new WorkoutLogDetail
            {
                Notes = entity.Notes,
                Date = entity.Date
            };
            return model;
        }

        public async Task<IEnumerable<WorkoutLogDetail>> GetWorkoutsByDateAsync(DateTime date)
        {
            var entity = await _db.WorkoutLog.Where(w => w.Date == date).Select(w =>
            new WorkoutLogDetail
            {
                Notes = w.Notes,
                Date = w.Date
            }).ToListAsync();
            return entity;
        }

        public async Task<bool> UpdateWorkoutsAsync(WorkoutLogUpdate model)
        {
            var workoutLog = await _db.WorkoutLog.FindAsync(model);
            var userId = int.Parse(_userManager.GetUserId(_signInManager.Context.User) ?? "0");
            if (workoutLog?.UserId != userId)
             _db.WorkoutLog.Update(workoutLog);
            return await _db.SaveChangesAsync() == 1;
            throw new NotImplementedException(); //Get workout log by Id
            // Entity.property = model.property
            // SaveChangesAsync
            // return changes == 1
        }

        public async Task<bool> DeleteWorkoutsAsync(int workoutId)
        {
            var workoutLog = await _db.WorkoutLog.FindAsync(workoutId);
            var userId = int.Parse(_userManager.GetUserId(_signInManager.Context.User) ?? "0");
            if (workoutLog?.UserId != userId)
                return false;
            _db.WorkoutLog.Remove(workoutLog);
            return await _db.SaveChangesAsync() == 1;

        }


    }
}