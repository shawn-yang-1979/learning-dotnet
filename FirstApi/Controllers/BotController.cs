using System;
using System.Collections.Generic;
using FirstLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BotController : ControllerBase
    {
        private readonly ILogger<BotController> _logger;
        private readonly Bot _service;
        public BotController(ILogger<BotController> logger, Bot service)
        {
            this._logger = logger;
            this._service = service;
        }
        [HttpPost]
        public string SayHi()
        {
            return _service.SayHi();
        }
        [HttpPost]
        public string SplitCandies([FromForm] int candies, [FromForm] int groups)
        {
            return _service.SplitCandies(candies, groups);
        }

        [HttpPost]
        public decimal AddNumbers([FromBody] AddNumbersInput input)
        {
            return _service.AddNumbers(input.Numbers);
        }

        [HttpPost]
        public string MakeBreakfast()
        {
            DateTime departure = DateTime.Now;

            _service.MakeBreakfast();

            DateTime arrival = DateTime.Now;
            TimeSpan travelTime = arrival - departure;
            return $"Spent {travelTime.TotalSeconds} seconds.";
        }

        [HttpPost]
        public string FindUniqueNumbers([FromBody] AddNumbersInput input)
        {
            IEnumerable<decimal> result = _service.FindUniqueNumbers(input.Numbers);
            return result.ToString();
        }
    }

    public class AddNumbersInput
    {
        public List<decimal> Numbers { get; set; }
    }
}