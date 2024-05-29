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
        private ApplicationUser GuestUser { get; set; }
        private ApplicationUser AdminUser { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUsers();
            builder.Entity<ApplicationUser>()
                .HasData(GuestUser, AdminUser);

            Assembly configAssembly = Assembly.GetAssembly(typeof(MathPreparationAppDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            GuestUser = new ApplicationUser()
            {
                Id = Guid.Parse("fa76088c-c053-4a4b-a0c5-bb931c606c78"),
                UserName = "guest@users.com",
                NormalizedUserName = "GUEST@USERS.COM",
                Email = "guest@users.com",
                NormalizedEmail = "GUEST@USERS.COM",
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "Guest123!");

            AdminUser = new ApplicationUser()
            {
                Id = Guid.Parse("bcb4f072-ecca-43c9-ab26-c060c6f364e4"),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
            };
            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "Admin123!");
        }
    }
}