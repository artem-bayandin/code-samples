using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeds
{
    public class QuizSeed : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            var id = 1;

            int NextId()
            {
                ++id;
                return id;
            }

            var data = new List<Quiz>
            {
                new Quiz(
                    NextId()
                    , "Yes / No"
                    , new QuizNode(
                        NextId()
                        , "Do you want to start?"
                        , new List<QuizNodeRelation>
                        {
                            new QuizNodeRelation("yes", new QuizNode(NextId(), "second step if yes", new List<QuizNodeRelation>
                            {
                            })),
                            new QuizNodeRelation("no", new QuizNode(NextId(), "Yeah! Thanks for not playing!"))
                        }
                    )
                ),
                new Quiz(
                    NextId()
                    , "Multi nodes"
                    , new QuizNode(
                        NextId()
                        , "Do you want to start?"
                        , new List<QuizNodeRelation>
                        {
                            new QuizNodeRelation("yes", new QuizNode(NextId(), "second step if yes", new List<QuizNodeRelation>
                            {
                            })),
                            new QuizNodeRelation("no", new QuizNode(NextId(), "Yeah! Thanks for not playing!")),
                            new QuizNodeRelation("not sure", new QuizNode(NextId(), "Hmm... Are you a human?", new List<QuizNodeRelation>
                            {
                                new QuizNodeRelation("not sure", new QuizNode(NextId(), "You have chosen the right one.")),
                                new QuizNodeRelation("not sure", new QuizNode(NextId(), "You have chosen the left one."))
                            })),
                        }
                    )
                )
            }
            .ToList();

            builder.HasData(data);
        }
    }
}
