using MathPreparationApp.Data.Models;

namespace MathPreparationApp.Services.Data.Interfaces
{
    using MathPreparationApp.Web.ViewModels.Topic;
    using Web.ViewModels.Question;

    public interface IQuestionService
    {
        Task AddAsync(QuestionFormModel formModel);

        Task<bool> QuestionExistsByIdAsync(string questionId);

        Task<QuestionEditFormModel> GetQuestionByIdAsync(string questionId);
        Task<QuestionDeleteViewModel> GetQuestionForDeleteByIdAsync(string questionId);

        Task EditAsync(string questionId, QuestionEditFormModel formModel);
        Task DeleteAsync(string questionId);

        Task<IQueryable<Question>> GetNotAnsweredBeforeQuestionsAsync();
        Task<IQueryable<Question>> GetNeverAnsweredCorrectlyQuestionsAsync();
    }
}
