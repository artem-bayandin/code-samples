using Domain.Ports.Records;
using Domain.Ports.In.Result;
using MediatR;

namespace Domain.PortsImplementation.Quiz.GetQuizzesNames
{
    public record GetQuizzesNamesQuery : IRequest<DomainRequestResult<IEnumerable<QuizNameRecord>>>;
}
