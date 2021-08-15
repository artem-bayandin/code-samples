using Domain.Ports.Records;
using Domain.Ports.In.Result;

namespace Domain.Ports.In
{
    public interface IQuizPortIn
    {
        Task<DomainRequestResult<IEnumerable<QuizNameRecord>>> GetQuizzesNames();
        Task<DomainRequestResult<QuizRecord>> GetQuizById(int quizId);
        Task<DomainRequestResult<IEnumerable<UserAnswersForQuizRecord>>> GetUserAnswersForQuiz(Guid userId, int quizId);
        Task<DomainRequestResult> SaveUserAnswersForQuiz(Guid userId, int quizId, IEnumerable<int> selectedNodes);
    }
}
