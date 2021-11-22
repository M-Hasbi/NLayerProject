using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_LayerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PersonsController(IService<Person> personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Persons = await _personService.GetAllAsync();
            return Ok(Persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson = await _personService.AddAsync(person);

            return Ok(newPerson);
        }

    }
}
