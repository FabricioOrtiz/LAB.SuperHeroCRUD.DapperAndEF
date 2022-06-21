using LAB.SuperHeroCRUD.Application.SuperHeroCRUD;
using LAB.SuperHeroCRUD.Model;
using LAB.SuperHeroCRUD.Persistence.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LAB.SuperHeroCRUD.Controllers
{
    [ApiController]
    [Route("api/superhero")]
    public class SuperHeroController : Controller
    {
        private readonly IMediator _mediator;
        public SuperHeroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> create(Create.SuperHero request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroDTO>>> list()
        {
            return await _mediator.Send(new Find.ListSuperHero());
        }

        [HttpGet("id")]
        public async Task<ActionResult<SuperHeroDTO>> get(int id)
        {
            return await _mediator.Send(new FindBy.EspecialSuperHero { Id = id });
        }
    }
}
