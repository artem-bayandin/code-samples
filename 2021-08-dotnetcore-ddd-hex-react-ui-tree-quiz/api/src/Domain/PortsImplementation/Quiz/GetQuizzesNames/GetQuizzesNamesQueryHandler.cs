using Domain.Ports.Records;
using Domain.Ports.In.Result;
using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;

namespace Domain.PortsImplementation.Quiz.GetQuizzesNames
{
    public class GetQuizzesNamesQueryHandler : BaseHandler<GetQuizzesNamesQuery, DomainRequestResult<IEnumerable<QuizNameRecord>>>
    {
        private readonly IQuizPortOut _quizPortOut;

        public GetQuizzesNamesQueryHandler(IQuizPortOut quizPortOut)
        {
            _quizPortOut = quizPortOut;
        }

        protected override async Task<DomainRequestResult<IEnumerable<QuizNameRecord>>> DoTheJob(GetQuizzesNamesQuery request, CancellationToken cancellationToken)
        {
            return DomainRequestResult<IEnumerable<QuizNameRecord>>.Ok(await _quizPortOut.GetQuizNames());
        }
    }
}
