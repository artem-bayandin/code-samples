using Domain.Ports.Records;

namespace Domain.Ports.Out
{
    public interface IQuizPortOut
    {
        Task<bool> QuizExist(int quizId);
        Task<IEnumerable<QuizNameRecord>> GetQuizNames();
        Task<QuizRecord> GetQuizById(int quizId);
        Task<UserAnswersForQuizRecord> GetUserAnswersForQuiz(Guid userId, int quizId);
        Task SaveUserAnswersForQuiz(Guid userId, int quizId, List<int> selectedNodes);
    }
}
