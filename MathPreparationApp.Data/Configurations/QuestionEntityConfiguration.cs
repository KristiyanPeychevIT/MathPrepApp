namespace MathPreparationApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.AddedOn)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(q => q.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");


            builder
                .HasOne(q => q.Subject)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(q => q.Topic)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TopicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(q => q.UsersAnswered)
                .WithMany(u => u.AnsweredQuestions)
                .UsingEntity<UserAnsweredQuestion>();

            builder.HasData(this.GenerateQuestions());
        }

        private Question[] GenerateQuestions()
        {
            ICollection<Question> questions = new HashSet<Question>();

            Question question;

            question = new Question
            {
                Name = "Пресметнете стойността на израза: 4.(-8)",
                Option1 = "32",
                Option2 = "-32",
                Option3 = "-12",
                Option4 = "12",
                CorrectOption = "-32",
                Points = 2,
                ImageBytes = null,
                Solution = "Положително число, умножено с отрицателно, е равно на отрицателното им произведение.",
                SubjectId = 1,
                TopicId = 2,
                AddedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            questions.Add(question);

            question = new Question
            {
                Name = "Запишете в нормален вид едночлена: 5xxyy\u00b2z",
                Option1 = "5xyy",
                Option2 = "5x\u00b3yz",
                Option3 = "5xy³z",
                Option4 = "5x²y³z",
                CorrectOption = "5x²y³z",
                Points = 2,
                ImageBytes = null,
                Solution = "x по x = x², y по у\u00b2 = y\u00b3",
                SubjectId = 2,
                TopicId = 2,
                AddedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            questions.Add(question);

            return questions.ToArray();
        }
    }
}
