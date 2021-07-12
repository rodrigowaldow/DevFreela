using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    public class SkillsController : ControllerBase
    {
        //Refactoring from MediatR
        //private readonly ISkillService _skillService;

        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var skills = _skillService.GetAll();

            var getAllSkillsQuery = new GetAllSkillsQuery();

            var skills = await _mediator.Send(getAllSkillsQuery);

            return Ok(skills);
        }
    }
}
