using AutoMapper;
using LAB.SuperHeroCRUD.Model;
using LAB.SuperHeroCRUD.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LAB.SuperHeroCRUD.Application
{
    public class FindSuperHero 
    {
        //Se usa una clase para mapear los valores de entrada y salida
        public class ListSuperHero : IRequest<List<SuperHeroDTO>> { }

        public class Mediator : IRequestHandler<ListSuperHero, List<SuperHeroDTO>>
        {
            private readonly DBContext _dbContext;
            private readonly IMapper _mapper;
            public Mediator(DBContext dBContext, IMapper mapper)
            {
                _dbContext = dBContext;
                _mapper = mapper;
            }
            public async Task<List<SuperHeroDTO>> Handle(ListSuperHero request, CancellationToken cancellationToken)
            {
                var superHeroList = await _dbContext.SuperHero.ToListAsync();
                var superHeroDTO = _mapper.Map<List<SuperHero>, List<SuperHeroDTO>>(superHeroList);
                return superHeroDTO;
            }
        }
    }
}
