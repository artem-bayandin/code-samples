namespace Infrastructure.Persistence.Entities
{
    public record Quiz(int Id, string Name, QuizNode Root = null)
    {
        public virtual ICollection<QuizUserAnswer> Answers { get; set; }
    }
}
