using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador4B.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIntegrador4B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly projetointegrador3bContext _context;
        public ReportController(projetointegrador3bContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("inferiorNow")]
        public IEnumerable ReportInf()
        {

            var query = from p in _context.Person
                        join pg in _context.Persongroup
                        on p.Id equals pg.Idperson
                        join gv in _context.Groupvaccination
                        on pg.Idgroup equals gv.Id
                        where gv.Liberationdate <= DateTime.Now
                        orderby gv.Liberationdate
                        select new { Name = p.Name, Email = p.Email, Description = gv.Description, LiberationDate = gv.Liberationdate };

            return query.ToList();

        }

        [HttpGet]
        [Route("superiorNow")]
        public IEnumerable ReportSup()
        {

            var query = from p in _context.Person
                        join pg in _context.Persongroup
                        on p.Id equals pg.Idperson
                        join gv in _context.Groupvaccination
                        on pg.Idgroup equals gv.Id
                        where gv.Liberationdate >= DateTime.Now
                        orderby gv.Liberationdate
                        select new { Name = p.Name, Email = p.Email, Description = gv.Description, LiberationDate = gv.Liberationdate };

            return query.ToList();

        }


        [HttpGet]
        [Route("all")]
        public IEnumerable ReportAll()
        {

            var query = from p in _context.Person
                        join pg in _context.Persongroup
                        on p.Id equals pg.Idperson
                        join gv in _context.Groupvaccination
                        on pg.Idgroup equals gv.Id
                        orderby gv.Liberationdate
                        select new { Name = p.Name, Email = p.Email, Description = gv.Description, LiberationDate = gv.Liberationdate };

            return query.ToList();

        }
    }
}