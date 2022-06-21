using AutoMapper;
using LAB.SuperHeroCRUD.Model;
using LAB.SuperHeroCRUD.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LAB.SuperHeroCRUD.Application.SuperHeroCRUD
{
    public class FindBy
    {
        public class EspecialSuperHero : IRequest<SuperHeroDTO>
        { 
            public int Id { get; set; }
        }

        public class Mediator : IRequestHandler<EspecialSuperHero, SuperHeroDTO>
        {
            private readonly DBContext _dbContext;
            private readonly IMapper _mapper;
            public Mediator(DBContext dBContext, IMapper mapper)
            {
                _dbContext = dBContext;
                _mapper = mapper;
            }
            public async Task<SuperHeroDTO> Handle(EspecialSuperHero request, CancellationToken cancellationToken)
            {
                var superHero = await _dbContext.SuperHero.Where(obj => obj.Id == request.Id).FirstOrDefaultAsync();
                if (superHero == null)
                    throw new Exception("the super hero not did not answer the call.!!!");

                var superHeroDTO = _mapper.Map<SuperHero, SuperHeroDTO>(superHero);
                return superHeroDTO;
            }
        }
    }
}
