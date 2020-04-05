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
    public class GreetingService : IGreetingService
    {
        private readonly test_dbContext db;

        public GreetingService(test_dbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Greeting> Get()
        {
            return db.Greeting.AsEnumerable();
        }
    }
}
