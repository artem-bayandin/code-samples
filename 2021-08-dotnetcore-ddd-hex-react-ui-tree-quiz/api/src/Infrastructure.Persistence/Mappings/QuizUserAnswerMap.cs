using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Persistence.Mappings
{
    public class QuizUserAnswerMap : IEntityTypeConfiguration<QuizUserAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizUserAnswer> builder)
        {
            builder.HasKey(x => new { x.QuizId, x.UserId });
            builder.HasOne(x => x.Quiz).WithMany(x => x.Answers);
            builder.HasOne(x => x.User).WithMany(x => x.Answers);

            // TODO quick fix for storing list as JSON
            // error: The property is a collection or enumeration type with a value converter but with no value comparer. Set a value comparer
            var selectedNodesValueComparer = new ValueComparer<List<int>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());
            builder
                .Property(x => x.SelectedNodes)
                .Metadata
                .SetValueComparer(selectedNodesValueComparer);

            builder
                .Property(x => x.SelectedNodes)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<int>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
