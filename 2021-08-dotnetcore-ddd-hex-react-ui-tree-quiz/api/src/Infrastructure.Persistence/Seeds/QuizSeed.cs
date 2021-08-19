using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Seeds
{
    public class QuizSeed : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            var data = new List<Quiz>
            {
                new Quiz(
                    NextId()
                    , "Multi nodes test"
                    , new QuizNode(
                        NextId()
                        , "Do you want to start?"
                        , new List<QuizNodeRelation>
                        {
                            new QuizNodeRelation("yes", new QuizNode(NextId(), "You clicked 'yes', great. That's the end")),
                            new QuizNodeRelation("no", new QuizNode(NextId(), "Yeah! Thanks for NOT playing!")),
                            new QuizNodeRelation("not sure", new QuizNode(NextId(), "Hmm... Are you a human?", new List<QuizNodeRelation>
                            {
                                new QuizNodeRelation("not sure", new QuizNode(NextId(), "You have chosen the right one.")),
                                new QuizNodeRelation("not sure", new QuizNode(NextId(), "You have chosen the left one."))
                            })),
                        }
                    )
                ),
                new Quiz(
                    NextId()
                    , "Long Quiz"
                    , new QuizNode(
                        NextId()
                        , "How are you?"
                        , new List<QuizNodeRelation>
                        {
                            new QuizNodeRelation(
                                "fine"
                                , new QuizNode(
                                    NextId()
                                    , "Not bad, not bad. Are you waiting for a weekend to have a rest?"
                                    , GetListOfQuestions()
                                )
                            ),
                            new QuizNodeRelation(
                                "brilliant"
                                , new QuizNode(
                                    NextId()
                                    , "Great to hear! But I have not prepared another questions to you, rather than from the first option. So, are you waiting for a weekend to have a rest?"
                                    , GetListOfQuestions()
                                )
                            )
                        }
                    )
                )
            }
            .ToList();

            builder.HasData(data);
        }

        private int _id = 1;

        private int NextId()
        {
            return _id++;
        }

        private List<QuizNodeRelation> GetListOfQuestions()
        {
            return new List<QuizNodeRelation>
                                    {
                                        new QuizNodeRelation(
                                            "yes"
                                            , new QuizNode(
                                                NextId()
                                                , "Nice to hear. And what will you do?"
                                                , new List<QuizNodeRelation>
                                                {
                                                    new QuizNodeRelation(
                                                        "drink beer"
                                                        , new QuizNode(
                                                            NextId()
                                                            , "Dark or light?"
                                                            , new List<QuizNodeRelation>
                                                            {
                                                                new QuizNodeRelation(
                                                                    "dark"
                                                                    , new QuizNode(
                                                                        NextId()
                                                                        , "I will call you 'Dark Knight' now)"
                                                                    )
                                                                ),
                                                                new QuizNodeRelation(
                                                                    "light"
                                                                    , new QuizNode(
                                                                        NextId()
                                                                        , "Light is for girls, urgh... I have no more questions."
                                                                    )
                                                                ),
                                                                new QuizNodeRelation(
                                                                    "Budweiser"
                                                                    , new QuizNode(
                                                                        NextId()
                                                                        , "Great choice! Feel free to fill you tanks!"
                                                                    )
                                                                ),
                                                            }
                                                        )
                                                    ),
                                                    new QuizNodeRelation(
                                                        "do sports"
                                                        , new QuizNode(
                                                            NextId()
                                                            , "Nice to hear. And what will you do?"
                                                            , new List<QuizNodeRelation>
                                                            {
                                                                new QuizNodeRelation(
                                                                    "lazy chillin'"
                                                                    , new QuizNode(
                                                                        NextId()
                                                                        , "Ha-ha! Okay, have a rest."
                                                                    )
                                                                ),
                                                                new QuizNodeRelation(
                                                                    "Nike"
                                                                    , new QuizNode(
                                                                        NextId()
                                                                        , "Just do it!"
                                                                    )
                                                                ),
                                                            }
                                                        )
                                                    ),
                                                    new QuizNodeRelation(
                                                        "lazy chillin'"
                                                        , new QuizNode(
                                                            NextId()
                                                            , "Ha-ha! Okay, have a rest."
                                                        )
                                                    ),
                                                }
                                            )
                                        ),
                                        new QuizNodeRelation(
                                            "no"
                                            , new QuizNode(
                                                NextId()
                                                , "No? So you have no plan to feel better and answer 'brilliant' next time?"
                                                , new List<QuizNodeRelation>
                                                {
                                                    new QuizNodeRelation(
                                                        "yes"
                                                        , new QuizNode(
                                                            NextId()
                                                            , "Okay. Bye."
                                                        )
                                                    )
                                                }
                                            )
                                        )
                                    };
        }
    }
}
