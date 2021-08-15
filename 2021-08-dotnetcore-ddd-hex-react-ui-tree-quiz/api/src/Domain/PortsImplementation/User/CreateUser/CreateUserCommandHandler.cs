using Domain.Ports.In.Result;
using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public class CreateUserCommandHandler : BaseHandler<CreateUserCommand, DomainRequestResult<Guid>>
    {
        private readonly IUserPortOut _userPortOut;

        public CreateUserCommandHandler(IUserPortOut userPortOut)
        {
            _userPortOut = userPortOut;
        }

        protected override async Task<DomainRequestResult<Guid>> DoTheJob(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = await _userPortOut.CreateUser();
            return DomainRequestResult<Guid>.Ok(userId);
        }
    }
}
