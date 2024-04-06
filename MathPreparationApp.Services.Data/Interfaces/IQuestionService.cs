namespace MathPreparationApp.Services.Data.Interfaces
{
    using Web.ViewModels.Question;

    public interface IQuestionService
    {
        Task AddAsync(QuestionFormModel formModel);

        Task<bool> QuestionExistsByIdAsync(string questionId);

        Task<QuestionEditFormModel> GetQuestionByIdAsync(string questionId);

        Task EditAsync(string questionId, QuestionEditFormModel formModel);
    }
}
