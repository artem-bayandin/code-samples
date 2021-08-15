using Domain.Ports.In.Result;

namespace Domain.Ports.In
{
    public interface IUserPortIn
    {
        Task<DomainRequestResult<Guid>> CreateUser();
    }
}
