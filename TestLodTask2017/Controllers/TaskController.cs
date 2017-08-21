using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TestLodTask2017.Entities;
using TestLodTask2017.Models;

namespace TestLodTask2017.Controllers
{
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly Population _population;
        private readonly HumanMapper _humanMapper;
        
        public TaskController(IOptions<Population> population, HumanMapper humanMapper)
        {
            _humanMapper = humanMapper;
            _population = population.Value;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_population.People.Select(_humanMapper.HumanToShortModel));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var person = _population.People.SingleOrDefault(human => human.Id == id);

            if (person == null)
            {
                return NotFound("Person with this id not found");
            }

            return Ok(_humanMapper.HumanToExpandedHumanModel(person));
        }
    }
}