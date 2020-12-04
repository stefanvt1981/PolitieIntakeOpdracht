using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolitieIntakeOpdracht.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentTimeController : ControllerBase
    {
        private readonly ILogger<CurrentTimeController> _logger;

        public CurrentTimeController(ILogger<CurrentTimeController> logger) => _logger = logger;

        [HttpGet("{cityName}/{countryCode?}")]
        public string Get(string cityName, string countryCode = null)
        {
            return $"{cityName}, {(string.IsNullOrEmpty(countryCode) ? "Unknown" : countryCode)}";
        }
    }
}
