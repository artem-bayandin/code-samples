using Domain.Ports.Records;
using Domain.Ports.In.Result;
using MediatR;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public record GetQuizByIdQuery(int QuizId) : IRequest<DomainRequestResult<QuizRecord>>;
}
