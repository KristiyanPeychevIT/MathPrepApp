namespace MathPreparationApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class SubjectEntityConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(this.GenerateSubjects());
        }
        private Subject[] GenerateSubjects()
        {
            ICollection<Subject> subjects = new HashSet<Subject>();

            Subject subject;

            subject = new Subject
            {
                Id = 1,
                Name = "Начален преговор от 6. клас"
            };
            subjects.Add(subject);

            subject = new Subject
            {
                Id = 2,
                Name = "Цели изрази"
            };
            subjects.Add(subject);

            return subjects.ToArray();
        }
    }
}
