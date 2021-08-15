using Domain.Ports.In;
using Infrastructure.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : BaseController
    {
        private readonly IQuizPortIn _quizPort;

        public QuizController(IQuizPortIn quizPort)
        {
            _quizPort = quizPort;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetQuizzes()
        {
            return Result(await _quizPort.GetQuizzesNames());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizz(int id)
        {
            return Result(await _quizPort.GetQuizById(id));
        }
    }
}
