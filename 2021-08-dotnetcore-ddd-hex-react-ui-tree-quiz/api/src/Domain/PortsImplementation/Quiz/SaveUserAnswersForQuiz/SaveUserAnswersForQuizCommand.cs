using Domain.Ports.In.Result;
using MediatR;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public record SaveUserAnswersForQuizCommand(Guid UserId, int QuizId, List<int> SelectedNodes) : IRequest<DomainRequestResult>;
}
