using APIPadawans.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPadawans.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("PadawansAdd")]
        public ActionResult<bool> PadawansAdd(Padawans viewModel)
        {
            List<Padawans> lista = new List<Padawans>();

            if(viewModel.Id < 0) { return BadRequest(false); };

            if (string.IsNullOrEmpty(viewModel.name)) 
            { 
                return BadRequest(false); 
            };

            if (viewModel.Age > 13) { return BadRequest(false); }

            if (viewModel.Complete == true && viewModel.CutHair == false)
            {
                return BadRequest(false);
            }

            lista.Add(viewModel);
            return Ok(true);
        }





        [HttpGet("PadawansList")]
        public IEnumerable<Padawans> PadawansList()
        {
            List<Padawans> lista = new List<Padawans>();

            lista.Add(new Padawans() { Id = 0, name = "Mateus", Age = 21, Complete = false, CutHair = false  });
            lista.Add(new Padawans() { Id = 1, name = "Mendes", Age = 22, Complete = false, CutHair = false });
            lista.Add(new Padawans() { Id = 2, name = "Mateus", Age = 39, Complete = false, CutHair = false });

            return lista;
        }
    }
}
