using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador4B.Dtos;
using ProjetoIntegrador4B.Helpers;
using ProjetoIntegrador4B.Models;
using System;
using System.Collections;
using System.Linq;

namespace ProjetoIntegrador4B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly projetointegrador3bContext _context;
        public LoginController(projetointegrador3bContext context)
        {
            _context = context;
        }

        [HttpPost]
        public LoginDto Login(Useradm useradm)
        {
            LoginDto result = new LoginDto();
            bool tokenCorrect = false;

            bool exists = _context.Useradm.Any(t => t.Email == useradm.Email); ;

            if (!exists)
            {
                return result;
            }

            var user = _context.Useradm.First(t => t.Email == useradm.Email);

            tokenCorrect = EasyMD5.Verify(useradm.Password, user.Password);



            if (tokenCorrect)
            {
                result.Name = user.Name;
                result.Success = true;
                result.Token = user.Token;
            }

            return result;
        }

        [HttpPut]
        public int Create(Useradm useradm)
        {
            useradm.Password = EasyMD5.Hash(useradm.Password);
            int random = new Random().Next();
            useradm.Token = EasyMD5.Hash(useradm.Password + random);
            _context.Useradm.Add(useradm);
            return _context.SaveChanges();
        }

        [HttpGet("{id}")]
        public IEnumerable One(int id)
        {

            var user = _context.Useradm
                .Select(f => new
                {
                    Id = f.Id,
                    Email = f.Email,
                    Name = f.Name
                }).Where(c => c.Id == id).ToList();

            return user;
        }

        [HttpDelete("{id}")]
        public int delete(int id)
        {
            var entity = _context.Useradm.FirstOrDefault(t => t.Id == id);
            _context.Useradm.Remove(entity);
            return _context.SaveChanges();

        }

    }
}