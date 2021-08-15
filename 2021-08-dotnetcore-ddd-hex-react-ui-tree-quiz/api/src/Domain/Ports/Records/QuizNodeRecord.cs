namespace Domain.Ports.Records
{
    public record QuizNodeRecord(int Id, string Text, IEnumerable<QuizNodeRelationRecord> Children = null);
}
