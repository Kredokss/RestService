using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestService.BLL.Abstract;
using RestService.DAL.Entities;

namespace RestService.BLL.Services
{
    public class CountryService : ICountryService
    {
        private readonly test_dbContext db;

        public CountryService(test_dbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Country> Get()
        {
            return db.Country.AsEnumerable();
        }
    }
}
