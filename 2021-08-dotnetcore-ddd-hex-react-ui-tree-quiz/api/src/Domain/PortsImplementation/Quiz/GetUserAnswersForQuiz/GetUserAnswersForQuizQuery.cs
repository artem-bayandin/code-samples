using Domain.Ports.Records;
using Domain.Ports.In.Result;
using MediatR;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public record GetUserAnswersForQuizQuery(Guid UserId, int QuizId) : IRequest<DomainRequestResult<IEnumerable<UserAnswersForQuizRecord>>>;
}
