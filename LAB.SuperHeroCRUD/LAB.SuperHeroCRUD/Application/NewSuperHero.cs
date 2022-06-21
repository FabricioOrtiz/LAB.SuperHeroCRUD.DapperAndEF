using MediatR;

namespace LAB.SuperHeroCRUD.Application
{
    public class NewSuperHero 
    {
        public class Execute : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Place { get; set; }
        }

        //public class Mediator : IRequestHandler<NewSuperHero>
        //{
            
        //    public Mediator()
        //    {

        //    }
        //    public Task<Unit> Handle(NewSuperHero request, CancellationToken cancellationToken)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
