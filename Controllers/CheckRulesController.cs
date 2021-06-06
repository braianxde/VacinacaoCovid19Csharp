using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador4B.Dtos;
using ProjetoIntegrador4B.Models;
using System.Collections.Generic;
using System.Linq;


namespace ProjetoIntegrador4B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckRulesController : ControllerBase
    {
        private readonly projetointegrador3bContext _context;
        public CheckRulesController(projetointegrador3bContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ResultDto CheckRules(CheckRuleDto form)
        {
            List<Groupvaccination> list = new List<Groupvaccination>();
            ResultDto result = new ResultDto();
            result.Status = false;
            result.Description = "Sem previsão de vacinação para o(s) grupo(s) informados";
            foreach (int id in form.IdItems)
            {
                Groupvaccination group = _context.Groupvaccination
                .Where(c => c.Id == id)
                .FirstOrDefault();

                if (group != null)
                {
                    if (group.Liberationdate != null)
                    {
                        list.Add(group);
                    }
                }
            }

            List<Groupvaccination> objRuleOrder = list.OrderBy(order => order.Liberationdate).ToList();

            foreach (Groupvaccination group in objRuleOrder)
            {
                result.Status = true;
                result.Date = group.Liberationdate;
                result.Description = group.Description;
                return result;
            }

            return result;
        }
    }
}