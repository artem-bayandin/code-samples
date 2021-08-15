using Domain.Ports.In;
using Domain.Ports.In.Result;
using Domain.PortsImplementation.Quiz.GetQuizById;
using MediatR;

namespace Domain.PortsImplementation.User
{
    public class UserPortIn : IUserPortIn
    {
        private readonly IMediator _mediator;

        public UserPortIn(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<DomainRequestResult<Guid>> CreateUser()
        {
            return await _mediator.Send(new CreateUserCommand());
        }
    }
}
