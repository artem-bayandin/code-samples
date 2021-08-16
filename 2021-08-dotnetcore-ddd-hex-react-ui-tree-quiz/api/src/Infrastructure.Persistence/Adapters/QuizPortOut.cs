using Domain.Ports.Records;
using Domain.Ports.Out;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Persistence.Adapters
{
    public class QuizPortOut : IQuizPortOut
    {
        private readonly IQuizContext _context;

        public QuizPortOut(IQuizContext context)
        {
            _context = context;
        }

        public async Task<QuizRecord> GetQuizById(int quizId)
        {
            var data = await _context
                .Quizzes
                //.Include(x => x.Root)
                .FirstOrDefaultAsync(x => x.Id == quizId);
            if (data == null) return null;

            // TODO: this step might be done via Automapper, later
            return new QuizRecord(data.Id, data.Name, ConvertToRecord(data.Root));
        }

        public async Task<IEnumerable<QuizNameRecord>> GetQuizNames()
        {
            var data = await _context
                .Quizzes
                .OrderBy(x => x.Id).ToListAsync();

            // TODO: this step might be done via Automapper, later
            var names = data
                .Select(x => new QuizNameRecord(x.Id, x.Name))
                .ToList();

            return names;
        }

        public async Task<UserAnswersForQuizRecord> GetUserAnswersForQuiz(Guid userId, int quizId)
        {
            var data = await _context.Answers.FirstOrDefaultAsync(x => x.QuizId == quizId && x.UserId == userId);
            if (data == null) return null;

            return new UserAnswersForQuizRecord(data.UserId, data.QuizId, data.SelectedNodes);
        }

        public async Task<bool> QuizExist(int quizId)
        {
            return await _context.Quizzes.AnyAsync(x => x.Id == quizId);
        }

        public async Task SaveUserAnswersForQuiz(Guid userId, int quizId, List<int> selectedNodes)
        {
            var existing = await _context.Answers.FirstOrDefaultAsync(x => x.QuizId == quizId && x.UserId == userId);
            if (existing == null)
            {
                var answers = new QuizUserAnswer(quizId, userId);
                answers.SelectedNodes = selectedNodes;
                await _context.Answers.AddAsync(answers);
            }
            else
            {
                existing.SelectedNodes = selectedNodes;
            }
        }


        // this should be done via Automapper
        private QuizNodeRecord ConvertToRecord(QuizNode node)
        {
            return new QuizNodeRecord(node.Id, node.Text, node.Children != null ? node.Children.Select(ConvertToRecord).ToList() : null);
        }

        // this should be done via Automapper
        private QuizNodeRelationRecord ConvertToRecord(QuizNodeRelation relation)
        {
            return new QuizNodeRelationRecord(relation.Relation, ConvertToRecord(relation.Node));
        }
    }
}
