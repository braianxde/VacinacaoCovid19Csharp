using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador4B.Dtos;
using ProjetoIntegrador4B.Models;

namespace ProjetoIntegrador4B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly projetointegrador3bContext _context;
        public FormController(projetointegrador3bContext context)
        {
            _context = context;
        }


        [HttpPost]
        public int Create(AddFormDto form)
        {

            _context.Person.Add(form.Person);
            _context.SaveChanges();

            foreach (int id in form.IdGroups)
            {
                Persongroup persongroup = new Persongroup(form.Person.Id, id);
                _context.Persongroup.Add(persongroup);
                _context.SaveChanges();
            }

            return 1;
        }
    }
}