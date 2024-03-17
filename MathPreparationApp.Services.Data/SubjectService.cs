using MathPreparationApp.Data.Models;

namespace MathPreparationApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Web.ViewModels.Subject;
    using MathPreparationApp.Data;

    public class SubjectService : ISubjectService
    {
        private readonly MathPreparationAppDbContext dbContext;

        public SubjectService(MathPreparationAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> SubjectExistsByIdAsync(int id)
        {
            return await dbContext.Subjects.AnyAsync(s => s.Id == id);
        }

        public async Task<bool> SubjectExistsByNameAsync(string name)
        {
            return await dbContext.Subjects.AnyAsync(s => s.Name == name);
        }

        public async Task AddSubject(SubjectFormModel model)
        {
            Subject newSubject = new Subject
            {
                Id = model.Id,
                Name = model.Name
            };

            await this.dbContext.Subjects.AddAsync(newSubject);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
