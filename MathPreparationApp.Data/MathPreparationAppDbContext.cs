namespace MathPreparationApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class MathPreparationAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public MathPreparationAppDbContext(DbContextOptions<MathPreparationAppDbContext> options)
            : base(options)
        {
        }
    }
}