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
    [Route("[controller]")]
    public class WorkoutController : Controller
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly IWorkoutLogService _service;

        public WorkoutController(ILogger<WorkoutController> logger, IWorkoutLogService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllWorkoutLogs();
            return View(model);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(WorkoutLogCreate model)
        {
            var res = await _service.CreateWorkoutLog(model);
            if (res)
            {
                return RedirectToAction(nameof (Index));
            } else
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}