using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Services;

namespace WheelOfFate.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class BauController : Controller
    {
        private readonly IBauService _bauService;

        public BauController(IBauService bauService) // Injection of IBauService
        {
            _bauService = bauService ?? throw new ArgumentNullException(nameof(bauService)); // Guard
        }

        [HttpGet("GetOptions")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public IActionResult GetBauScheduleStrategies()
        {
            List<string> result = _bauService.GetBauScheduleStrategies();
            return Json(result);
        }

        [HttpGet("Generate")]
        [ProducesResponseType(typeof(IEnumerable<BauSchedule>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GenerateBauSchedule(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees)
        {
            if (startDate < new DateTime(2018, 6, 1) || endDate < new DateTime(2018, 6, 1) || numberOfShifts <= 0 || numberOfEmployees <= 0)
                return BadRequest("Invalid data!");

            var result = _bauService.GenerateBauSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            return Json(result);
        }
    }
}