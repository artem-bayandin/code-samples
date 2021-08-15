namespace Domain.Ports.Records
{
    public record UserAnswersForQuizRecord(int UserId, int QuizId, IEnumerable<int> SelectedNodes);
}
