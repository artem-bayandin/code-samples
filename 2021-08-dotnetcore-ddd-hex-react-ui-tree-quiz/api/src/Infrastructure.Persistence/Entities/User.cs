namespace Infrastructure.Persistence.Entities
{
    public record User(Guid Id, string Name)
    {
        public virtual ICollection<QuizUserAnswer> Answers { get; set; }
    }
}
