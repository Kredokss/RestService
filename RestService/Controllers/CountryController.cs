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
    public class CountryController
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return countryService.Get();
        }
    }
}
