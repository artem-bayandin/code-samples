using Domain.Ports.In;
using Infrastructure.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IQuizPortIn _quizPort;
        private readonly IUserPortIn _userPortIn;

        public UserController(IQuizPortIn quizPort, IUserPortIn userPortIn)
        {
            _quizPort = quizPort;
            _userPortIn = userPortIn;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUser()
        {
            return Result(await _userPortIn.CreateUser());
        }

        [HttpGet("{userId}/quiz/{quizId}")]
        public async Task<IActionResult> GetQuizzAnswers(Guid userId, int quizId)
        {
            return Result(await _quizPort.GetUserAnswersForQuiz(userId, quizId));
        }

        [HttpPost("{userId}/quiz/{quizId}")]
        public async Task<IActionResult> SaveQuizzAnswers(Guid userId, int quizId, [FromBody] List<int> selectedNodes)
        {
            return Result(await _quizPort.SaveUserAnswersForQuiz(userId, quizId, selectedNodes));
        }
    }
}
