using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TestsBase
{
    public abstract class UnitTestsBase
    {
        // setup some common behavior here, like generic data generators, mapper service and so on
    }

    public class ValidatorMock<TCommand> where TCommand : class
    {
        // todo: use it to mock validator to be succeeded or not, assert results state
    }

    public abstract class ControllerTestsBase<TController> : UnitTestsBase
    {
        protected Mock<IMediator> Mediatr { get; set; }

        private TController _controller;

        protected TController Controller
        {
            get
            {
                if (_controller == null)
                {
                    // TODO: fix
                    //_controller = AutoFixture.Create<TController>();
                }

                return _controller;
            }
            set { _controller = value; }
        }

        protected ControllerTestsBase()
        {
            //SetupAutomoqForWebApi();

            // TODO: fix
            //Mediatr = AutoFixture.Freeze<Mock<IMediator>>();
        }

        // TODO: fix
        //protected async Task TestAction<TRequest, TRequestResult>(Func<TRequest, Task<IActionResult>> action)
        //    where TRequest : class, IRequest<TRequestResult>
        //    where TRequestResult : class, new()
        //{
        //    // arrange
        //    Mediatr
        //        .Setup(m => m.Send(It.IsAny<TRequest>(), It.IsAny<CancellationToken>()))
        //        .Returns(Task.FromResult(new TRequestResult()));
        //    var command = AutoFixture.Create<TRequest>();
        //    // act
        //    await action(command);
        //    // assert
        //    Mediatr.Verify(mediator => mediator.Send(It.Is<TRequest>(q => q == command), It.IsAny<CancellationToken>()));
        //}

        // TODO: fix
        //protected async Task TestAction<TRequest, TRequestResult>(Func<Task<IActionResult>> action)
        //    where TRequest : class, IRequest<TRequestResult>
        //    where TRequestResult : class, new()
        //{
        //    // arrange
        //    Mediatr
        //        .Setup(m => m.Send(It.IsAny<TRequest>(), It.IsAny<CancellationToken>()))
        //        .Returns(Task.FromResult(new TRequestResult()));
        //    // act
        //    await action();
        //    // assert
        //    Mediatr.Verify(mediator => mediator.Send(It.IsAny<TRequest>(), It.IsAny<CancellationToken>()));
        //}
    }
}
