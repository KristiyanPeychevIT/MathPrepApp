namespace MathPreparationApp.Services.Data.Interfaces
{
    using MathPreparationApp.Data.Models;
    using Web.ViewModels.Subject;

    public interface ISubjectService
    {
        Task<bool> SubjectExistsByIdAsync(int id);
        Task<bool> SubjectExistsByNameAsync(string name);

        Task AddAsync(SubjectFormModel viewModel);

        Task<Subject> GetSubjectByIdAsync(int id);

        Task EditAsync(int id, SubjectFormModel viewModel);

        Task DeleteAsync(SubjectViewModel viewModel);
    }
}
