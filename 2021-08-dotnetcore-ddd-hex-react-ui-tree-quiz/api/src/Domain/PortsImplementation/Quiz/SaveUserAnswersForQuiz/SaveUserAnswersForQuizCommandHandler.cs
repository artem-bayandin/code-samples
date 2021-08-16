using Domain.Ports.In.Result;
using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;
using FluentValidation;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public class SaveUserAnswersForQuizCommandHandler : BaseHandlerWithValidation<SaveUserAnswersForQuizCommand, DomainRequestResult>
    {
        private readonly IQuizPortOut _quizPortOut;
        private readonly IUnitOfWork _unitOfWork;

        public SaveUserAnswersForQuizCommandHandler(
            IValidator<SaveUserAnswersForQuizCommand> validator
            , IQuizPortOut quizPortOut
            , IUnitOfWork unitOfWork
            ) : base(validator)
        {
            _quizPortOut = quizPortOut;
            _unitOfWork = unitOfWork;
        }

        protected override async Task<DomainRequestResult> DoTheJob(SaveUserAnswersForQuizCommand request, CancellationToken cancellationToken)
        {
            await _quizPortOut.SaveUserAnswersForQuiz(request.UserId, request.QuizId, request.SelectedNodes);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return DomainRequestResult.Ok();
        }
    }
}
