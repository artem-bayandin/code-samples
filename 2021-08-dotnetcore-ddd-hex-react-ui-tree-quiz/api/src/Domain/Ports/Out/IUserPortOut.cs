namespace Domain.Ports.Out
{
    public interface IUserPortOut
    {
        Task<bool> UserExists(Guid userId);
        Task<Guid> CreateUser();
    }
}
