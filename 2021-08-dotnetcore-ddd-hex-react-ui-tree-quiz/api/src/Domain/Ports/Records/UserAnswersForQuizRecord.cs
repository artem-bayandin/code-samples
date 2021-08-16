namespace Domain.Ports.Records
{
    public record UserAnswersForQuizRecord(Guid UserId, int QuizId, List<int> SelectedNodes);
}
