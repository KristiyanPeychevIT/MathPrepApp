namespace MathPreparationApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class TopicEntityConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder
                .HasOne(t => t.Subject)
                .WithMany(s => s.Topics)
                .HasForeignKey(t => t.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateTopics());
        }
        private Topic[] GenerateTopics()
        {
            ICollection<Topic> topics = new HashSet<Topic>();

            Topic topic;

            topic = new Topic
            {
                Id = 1,
                Name = "Умножение и деление на рационални цисла",
                SubjectId = 1
            };
            topics.Add(topic);

            topic = new Topic
            {
                Id = 2,
                Name = "Едночлени",
                SubjectId = 2
            };
            topics.Add(topic);

            return topics.ToArray();
        }
    }
}
