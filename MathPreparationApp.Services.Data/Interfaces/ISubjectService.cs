namespace MathPreparationApp.Services.Data.Interfaces
{
    using Web.ViewModels.Subject;

    public interface ISubjectService
    {
        Task<bool> SubjectExistsByIdAsync(int id);
        Task<bool> SubjectExistsByNameAsync(string name);

        Task AddSubject(SubjectFormModel model);
    }
}
