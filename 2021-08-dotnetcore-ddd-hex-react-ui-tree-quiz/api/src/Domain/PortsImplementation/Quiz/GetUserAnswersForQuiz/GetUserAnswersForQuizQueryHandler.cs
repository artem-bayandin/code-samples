using Domain.Ports.Records;
using Domain.Ports.In.Result;
using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;
using FluentValidation;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public class GetUserAnswersForQuizQueryHandler : BaseHandlerWithValidation<GetUserAnswersForQuizQuery, DomainRequestResult<UserAnswersForQuizRecord>>
    {
        private readonly IQuizPortOut _quizPortOut;

        public GetUserAnswersForQuizQueryHandler(
            IValidator<GetUserAnswersForQuizQuery> validator
            , IQuizPortOut quizPortOut
            ) : base(validator)
        {
            _quizPortOut = quizPortOut;
        }

        protected override async Task<DomainRequestResult<UserAnswersForQuizRecord>> DoTheJob(GetUserAnswersForQuizQuery request, CancellationToken cancellationToken)
        {
            return DomainRequestResult<UserAnswersForQuizRecord>.Ok(await _quizPortOut.GetUserAnswersForQuiz(request.UserId, request.QuizId));
        }
    }
}
