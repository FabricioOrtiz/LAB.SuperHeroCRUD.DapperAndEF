using LAB.SuperHeroCRUD.Application;
using LAB.SuperHeroCRUD.Model;
using LAB.SuperHeroCRUD.Persistence.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LAB.SuperHeroCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : Controller
    {
        private readonly IMediator _mediator;
        public SuperHeroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(NewSuperHero.Execute request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroDTO>>> List()
        {
            return await _mediator.Send(new FindSuperHero.ListSuperHero());
        }
    }
}
