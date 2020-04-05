using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestService.BLL.Abstract;
using RestService.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController
    {
        private readonly IGreetingService greetingService;

        public GreetingController(IGreetingService countryService)
        {
            this.greetingService = countryService;
        }

        [HttpGet]
        public IEnumerable<Greeting> Get()
        {
            return greetingService.Get();
        }
    }
}
