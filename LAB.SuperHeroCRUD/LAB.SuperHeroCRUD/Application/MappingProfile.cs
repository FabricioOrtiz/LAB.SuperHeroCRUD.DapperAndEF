using AutoMapper;
using LAB.SuperHeroCRUD.Model;

namespace LAB.SuperHeroCRUD.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SuperHero, SuperHeroDTO>().
                ForMember(dto => dto.SecrectName, superHero => superHero.MapFrom(param => param.Name));
        }
    }
}
