namespace MathPreparationApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MathPreparationAppDbContext : IdentityDbContext
    {
        public MathPreparationAppDbContext(DbContextOptions<MathPreparationAppDbContext> options)
            : base(options)
        {
        }
    }
}