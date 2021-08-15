namespace Infrastructure.Persistence.Entities
{
    public record Quiz(int Id, string Name, QuizNode Root = null);
}
