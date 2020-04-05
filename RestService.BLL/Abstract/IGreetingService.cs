using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestService.DAL.Entities;

namespace RestService.BLL.Abstract
{
    public interface IGreetingService
    {
        IEnumerable<Greeting> Get();
    }
}
