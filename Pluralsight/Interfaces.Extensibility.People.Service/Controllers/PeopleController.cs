using Microsoft.AspNetCore.Mvc;
using Interfaces.Extensibility.People.Service.Models;
using Interfaces.Extensibility.PersonRepository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Interfaces.Extensibility.People.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IPeopleProvider provider;

        public PeopleController(IPeopleProvider provider)
        {
            this.provider = provider;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return provider.GetPeople();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return provider.GetPeople().FirstOrDefault(p => p.Id == id);
        }
    }
}
