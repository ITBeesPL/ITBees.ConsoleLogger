using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.ConsoleLogger
{
    public class DebugConsoleLoggerController : RestfulControllerBase<DebugConsoleLoggerController>
    {
        private readonly IDebugLogger _debugLogger;

        public DebugConsoleLoggerController(ILogger<DebugConsoleLoggerController> logger,
            IDebugLogger debugLogger) : base(logger)
        {
            _debugLogger = debugLogger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DebugRequestIm debugRequestIm)
        {
            _debugLogger.Save(debugRequestIm);
            return Ok();
        }
    }
}
