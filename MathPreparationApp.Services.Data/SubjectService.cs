namespace MathPreparationApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Web.ViewModels.Subject;
    using MathPreparationApp.Data;
    using System.Collections.Generic;

    using MathPreparationApp.Data.Models;

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

        public async Task AddAsync(SubjectFormModel model)
        {
            Subject newSubject = new Subject
            {
                Id = model.Id,
                Name = model.Name
            };

            await this.dbContext.Subjects.AddAsync(newSubject);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            Subject subject = await this.dbContext
                .Subjects.FirstAsync(s => s.Id == id);

            return subject;
        }

        public async Task EditAsync(int id, SubjectFormModel editedViewModel)
        {
            Subject subjectToEdit = await this.dbContext
                .Subjects
                .FirstAsync(s => s.Id == id);

            subjectToEdit.Name = editedViewModel.Name;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(SubjectViewModel viewModel)
        {
            Subject subjectToDelete = await this.dbContext
                .Subjects
                .FirstAsync(s => s.Id == viewModel.Id);

            this.dbContext.Subjects.Remove(subjectToDelete);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubjectViewModel>> AllSubjectsAsync()
        {
            IEnumerable<SubjectViewModel> allSubjects = await this.dbContext
                .Subjects
                .AsNoTracking()
                .Select(s => new SubjectViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToArrayAsync();

            return allSubjects;
        }

        public async Task<string> GetSubjectNameByIdAsync(int id)
        {
            Subject subject = await this.GetSubjectByIdAsync(id);

            return subject.Name;
        }
    }
}
