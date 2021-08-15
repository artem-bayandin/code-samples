namespace Infrastructure.Persistence.Entities
{
    public record QuizNode(int Id, string Text, IEnumerable<QuizNodeRelation> Children = null);
}
