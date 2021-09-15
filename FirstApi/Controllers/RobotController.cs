using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RobotController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Robot _robot;

        public RobotController(ILogger<WeatherForecastController> logger, Robot robot)
        {
            this._logger = logger;
            this._robot = robot;
        }

        [HttpPost]
        public string sayHi()
        {
            return _robot.Greeting();
        }
    }
}
