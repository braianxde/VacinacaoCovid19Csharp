using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador4B.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIntegrador4B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly projetointegrador3bContext _context;
        public PersonController(projetointegrador3bContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Person> All()
        {
            return _context.Person;
        }

        [HttpPost]
        public int Create(Person person)
        {
            _context.Person.Add(person);
            return _context.SaveChanges();
        }

        [HttpGet("{id}")]
        public Person One(int id)
        {
            return _context.Person
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        [HttpDelete("{id}")]
        public int delete(int id)
        {
            var entity = _context.Person.FirstOrDefault(t => t.Id == id);
            _context.Person.Remove(entity);
            return _context.SaveChanges();

        }

    }
}