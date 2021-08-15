using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;
using FluentValidation;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public class SaveUserAnswersForQuizCommandValidator : AbstractValidator<SaveUserAnswersForQuizCommand>
    {
        private readonly IQuizPortOut _quizPortOut;
        private readonly IUserPortOut _userPortOut;

        public SaveUserAnswersForQuizCommandValidator(IQuizPortOut quizPortOut, IUserPortOut userPortOut)
        {
            _quizPortOut = quizPortOut;
            _userPortOut = userPortOut;

            RuleFor(x => x.QuizId)
                .MustAsync(QuizExists)
                .WithMessage(BaseErrors.EntityWasNotFound);

            RuleFor(x => x.UserId)
                .MustAsync(UserExists)
                .WithMessage(BaseErrors.EntityWasNotFound);

            // TODO: later
            //RuleFor(x => x.SelectedNodes)
            //    .MustAsync(UserExists)
            //    .WithMessage(BaseErrors.EntityWasNotFound);
        }

        private async Task<bool> QuizExists(int quizId, CancellationToken cancellationToken)
        {
            return await _quizPortOut.QuizExist(quizId);
        }

        private async Task<bool> UserExists(Guid userId, CancellationToken cancellationToken)
        {
            return await _userPortOut.UserExists(userId);
        }
    }
}
