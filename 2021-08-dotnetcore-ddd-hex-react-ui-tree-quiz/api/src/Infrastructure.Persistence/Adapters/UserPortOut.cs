using Domain.Ports.Out;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Adapters
{
    public class UserPortOut : IUserPortOut
    {
        private readonly IQuizContext _context;

        public UserPortOut(IQuizContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateUser()
        {
            var id = Guid.NewGuid();
            var user = new User(id, id.ToString().Substring(0, 8)));
            await _context.Users.AddAsync(user);
            return id;
        }

        public async Task<bool> UserExists(Guid userId)
        {
            return await _context.Users.AnyAsync(x => x.Id == userId);
        }
    }
}
