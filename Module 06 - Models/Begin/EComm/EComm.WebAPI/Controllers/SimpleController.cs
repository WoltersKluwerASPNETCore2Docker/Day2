using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EComm.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SimpleController : Controller
    {
        public IConfiguration Configuration { get; }
        public SimpleController(IConfiguration configuration)
        {
            Configuration = configuration;

            Console.WriteLine("********* SimpleController *******************");
            Console.WriteLine("ConnectionStrings:DefaultConnection " +
                $"{Configuration["ConnectionStrings:DefaultConnection"]}");
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        [HttpGet("{count}")]
        public IEnumerable<string> Get(int count)
        {
            var data = new List<string>();
            for (var i = 0; i < count; i++) data.Add("Value" + i);
            return data;
        }
    }
}
