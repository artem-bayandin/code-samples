using Domain.Ports.Records;
using Domain.Ports.In.Result;
using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;
using FluentValidation;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public class GetQuizByIdQueryHandler : BaseHandlerWithValidation<GetQuizByIdQuery, DomainRequestResult<QuizRecord>>
    {
        private readonly IQuizPortOut _quizPortOut;

        public GetQuizByIdQueryHandler(
            IValidator<GetQuizByIdQuery> validator
            , IQuizPortOut quizPortOut
            ) : base(validator)
        {
            _quizPortOut = quizPortOut;
        }

        protected override async Task<DomainRequestResult<QuizRecord>> DoTheJob(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            return DomainRequestResult<QuizRecord>.Ok(await _quizPortOut.GetQuizById(request.QuizId));
        }
    }
}
