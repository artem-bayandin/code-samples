using Domain.Ports.In.Result;
using Domain.Ports.Out;
using Domain.PortsImplementation.BaseComponents;

namespace Domain.PortsImplementation.Quiz.GetQuizById
{
    public class CreateUserCommandHandler : BaseHandler<CreateUserCommand, DomainRequestResult<Guid>>
    {
        private readonly IUserPortOut _userPortOut;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserPortOut userPortOut, IUnitOfWork unitOfWork)
        {
            _userPortOut = userPortOut;
            _unitOfWork = unitOfWork;
        }

        protected override async Task<DomainRequestResult<Guid>> DoTheJob(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = await _userPortOut.CreateUser();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return DomainRequestResult<Guid>.Ok(userId);
        }
    }
}
