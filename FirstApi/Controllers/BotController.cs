using System.Collections.Generic;
using System.Threading;
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
            return _service.AddNumbers(input.numbers);
        }
    }

    public class AddNumbersInput
    {
        public List<decimal> numbers { get; set; }
    }
}