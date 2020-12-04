using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace PolitieIntakeOpdracht.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentTimeController : ControllerBase
    {
        private readonly ILogger<CurrentTimeController> _logger;

        public CurrentTimeController(ILogger<CurrentTimeController> logger) => _logger = logger;

        [HttpGet("{cityName}")]
        public ActionResult<CurrentTimeDTO> Get(string cityName)
        {
            try
            {                          
                var timeZoneInfo = TZConvert.GetTimeZoneInfo(TZConvert.RailsToIana(cityName));

                DateTime utcDate = DateTime.UtcNow;
                return Ok(new CurrentTimeDTO {
                    TimeZone = timeZoneInfo.DisplayName,
                    LocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timeZoneInfo).ToString("HH:mm:ss"),
                }) ;
            }
            catch (InvalidTimeZoneException)
            {
                return NotFound();
            }            
        }
    }
}
