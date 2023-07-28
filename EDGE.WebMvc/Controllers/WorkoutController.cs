using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EDGE.Models.WorkoutLog;
using EDGE.Services.Workouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EDGE.WebMvc.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly IWorkoutLogService _service;

        public WorkoutController(ILogger<WorkoutController> logger, IWorkoutLogService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllWorkoutLogs();
            return View(model);
        }

        public async Task<IActionResult> Detail()
        {
            var model = await _service.GetAllWorkoutLogs();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkoutLogCreate model)
        {
            if (ModelState.IsValid)
            {
                var isMessageCreated = await _service.CreateWorkoutLog(model);
                if (isMessageCreated)
                {
                    return RedirectToAction("Index", "Workout");
                }
                else
                {
                    return NotFound();
                }
            }
            return View();
        }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
    public async Task<IActionResult> Delete(int id)
    {
        WorkoutLogDetail? workoutLog = await _service.GetWorkoutLogByIDAsync(id);
        if (workoutLog is null)
            return RedirectToAction(nameof(Index));
        return View(workoutLog);
    }

    [HttpPost]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        await _service.DeleteWorkoutsAsync(id);
        return RedirectToAction(nameof(Index));
    }

}


}
