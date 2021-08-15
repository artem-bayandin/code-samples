using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;
using FluentValidation;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public class GetQuizByIdQueryValidator : AbstractValidator<GetQuizByIdQuery>
    {
        private readonly IQuizPortOut _quizPortOut;

        public GetQuizByIdQueryValidator(IQuizPortOut quizPortOut)
        {
            _quizPortOut = quizPortOut;

            RuleFor(x => x.QuizId)
                .MustAsync(QuizExists)
                .WithMessage(BaseErrors.EntityWasNotFound);
        }

        private async Task<bool> QuizExists(int quizId, CancellationToken cancellationToken)
        {
            return await _quizPortOut.QuizExist(quizId);
        }
    }
}
