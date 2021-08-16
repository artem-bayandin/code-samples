namespace Infrastructure.Persistence.Entities
{
    public record QuizUserAnswer(int QuizId, Guid UserId)
    {
        // should this be list?
        public virtual List<int> SelectedNodes { get; set; }

        public virtual User User { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
