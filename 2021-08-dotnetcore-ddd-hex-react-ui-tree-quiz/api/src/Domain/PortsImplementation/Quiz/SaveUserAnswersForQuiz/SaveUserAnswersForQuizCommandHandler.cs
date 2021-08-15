using Domain.Ports.In.Result;
using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;
using FluentValidation;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public class SaveUserAnswersForQuizCommandHandler : BaseHandlerWithValidation<SaveUserAnswersForQuizCommand, DomainRequestResult>
    {
        private readonly IQuizPortOut _quizPortOut;

        public SaveUserAnswersForQuizCommandHandler(
            IValidator<SaveUserAnswersForQuizCommand> validator
            , IQuizPortOut quizPortOut
            ) : base(validator)
        {
            _quizPortOut = quizPortOut;
        }

        protected override async Task<DomainRequestResult> DoTheJob(SaveUserAnswersForQuizCommand request, CancellationToken cancellationToken)
        {
            await _quizPortOut.SaveUserAnswersForQuiz(request.UserId, request.QuizId, request.SelectedNodes);
            return DomainRequestResult.Ok();
        }
    }
}
