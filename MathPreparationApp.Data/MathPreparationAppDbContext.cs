namespace MathPreparationApp.Data
{
    using System.Reflection;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using static Common.GeneralApplicationConstants;
    using Models;

    public class MathPreparationAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public MathPreparationAppDbContext(DbContextOptions<MathPreparationAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<UserAnsweredQuestion> UsersAnsweredQuestions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(MathPreparationAppDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}