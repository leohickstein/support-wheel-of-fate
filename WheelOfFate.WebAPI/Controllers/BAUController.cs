using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Service;

namespace WheelOfFate.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/BAU")]
    public class BAUController : Controller
    {
        private readonly IBAUService _BAUService;

        public BAUController(IBAUService BAUService)
        {
            _BAUService = BAUService ?? throw new ArgumentNullException(nameof(BAUService));
        }

        //[HttpGet]
        //public IActionResult GetBAUScheduleOptions()
        //{
        //    List<string> result = _BAUService.GetBAUScheduleAlgorithms();
        //    return Json(result);
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BAU>), 200)]
        public IActionResult GenerateBAUSchedules(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees)
        {
            List<Schedule> result = _BAUService.GenerateBAUSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            return Json(result);
        }
    }
}