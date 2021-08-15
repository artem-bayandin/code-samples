using Domain.Ports.In.Result;
using MediatR;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public record CreateUserCommand : IRequest<DomainRequestResult<Guid>>;
}
