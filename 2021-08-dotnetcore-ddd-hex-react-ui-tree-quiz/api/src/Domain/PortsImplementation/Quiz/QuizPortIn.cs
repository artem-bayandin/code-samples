using Domain.Ports.In;
using Domain.Ports.Records;
using Domain.Ports.In.Result;
using Domain.PortsImplementation.Quiz.GetQuizById;
using Domain.PortsImplementation.Quiz.GetQuizzesNames;
using MediatR;

namespace Domain.PortsImplementation.Quiz
{
    public class QuizPortIn : IQuizPortIn
    {
        private readonly IMediator _mediator;

        public QuizPortIn(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<DomainRequestResult<QuizRecord>> GetQuizById(int quizId)
        {
            return await _mediator.Send(new GetQuizByIdQuery(quizId));
        }

        public async Task<DomainRequestResult<IEnumerable<QuizNameRecord>>> GetQuizzesNames()
        {
            return await _mediator.Send(new GetQuizzesNamesQuery());
        }

        public async Task<DomainRequestResult<IEnumerable<UserAnswersForQuizRecord>>> GetUserAnswersForQuiz(Guid userId, int quizId)
        {
            return await _mediator.Send(new GetUserAnswersForQuizQuery(userId, quizId));
        }

        public async Task<DomainRequestResult> SaveUserAnswersForQuiz(Guid userId, int quizId, IEnumerable<int> selectedNodes)
        {
            return await _mediator.Send(new SaveUserAnswersForQuizCommand(userId, quizId, selectedNodes));
        }
    }
}
