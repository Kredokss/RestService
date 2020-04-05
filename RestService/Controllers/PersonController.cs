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
    [Route ("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpPut]
        public async Task<DataTransferPerson> Update([FromBody] DataTransferPerson person)
        {
            return await personService.Update(person);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<DataTransferPerson> Get(int id)
        {
            return await personService.Get(id);
        }
        [HttpGet]
        public IEnumerable<DataTransferPerson> Get()
        {
            return personService.Get();
        }
        [HttpPost]
        public async Task<DataTransferPerson> Add([FromBody] DataTransferPerson person)
        {
            return await personService.Add(person);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await personService.Delete(id);
        }

    }
}
