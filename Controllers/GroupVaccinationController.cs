using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador4B.Helpers;
using ProjetoIntegrador4B.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIntegrador4B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupVaccinationController : ControllerBase
    {
        private readonly projetointegrador3bContext _context;
        public GroupVaccinationController(projetointegrador3bContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Groupvaccination> All()
        {
            return _context.Groupvaccination;
        }

        [HttpPost]
        public int Update(Groupvaccination group)
        {
            Groupvaccination groupDb = _context.Groupvaccination
                .Where(c => c.Id == group.Id)
                .First();

            int change = 0;

            if (group.Description != groupDb.Description)
            {
                groupDb.Description = group.Description;
            }

            if (group.Liberationdate != groupDb.Liberationdate)
            {
                groupDb.Liberationdate = group.Liberationdate;
                change = 1;
            }

            _context.SaveChanges();

            if (change != 0)
            {
                var query = from p in _context.Person
                            join pg in _context.Persongroup
                            on p.Id equals pg.Idperson
                            join gv in _context.Groupvaccination
                            on pg.Idgroup equals gv.Id
                            where gv.Id == groupDb.Id
                            select p;

                IEnumerable<Person> person = query.ToList();
                string body = "Para pessoas que se encontram no grupo " + group.Description + " a data foi alterada para " + group.Liberationdate;
                foreach (Person p in person)
                {
                    Email.send(p.Email, body);
                }

                Telegram.sendMessage(body);
            }

            return 1;
        }

        [HttpPut]
        public int Create(Groupvaccination item)
        {
            _context.Groupvaccination.Add(item);
            return _context.SaveChanges();
        }

        [HttpGet("{id}")]
        public Groupvaccination One(int id)
        {
            return _context.Groupvaccination
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        [HttpDelete("{id}")]
        public int delete(int id)
        {
            var entity = _context.Groupvaccination.First(t => t.Id == id);
            _context.Groupvaccination.Remove(entity);
            return _context.SaveChanges();

        }
    }
}