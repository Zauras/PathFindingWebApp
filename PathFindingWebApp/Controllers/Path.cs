using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PathFindingWebApp.Models;
using PathFindingWebApp.Services.Facades;

namespace PathFindingWebApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class Path : ControllerBase
    {
        private static readonly int[] input =
        {
            1,2,0,3,0,2,0
        };

        private readonly ILogger<Path> _logger;
        private readonly IPathService _pathService;

        public Path(ILogger<Path> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public PathResultListDto Get(PathInputDto pathInput)
        {


            return null; //_pathService.CalculatePath(pathInput);
            //var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //     {
            //         Date = DateTime.Now.AddDays(index),
            //         TemperatureC = rng.Next(-20, 55),
            //         Summary = Summaries[rng.Next(Summaries.Length)]
            //     })
            //     .ToArray();
        }
        
    }
}