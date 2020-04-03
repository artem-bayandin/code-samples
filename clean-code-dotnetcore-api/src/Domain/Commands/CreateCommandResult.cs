namespace Domain.Commands
{
    public class CreateCommandResult<T>
    {
        T Id { get; }

        public CreateCommandResult(T id)
        {
            Id = id;
        }
    }
}
