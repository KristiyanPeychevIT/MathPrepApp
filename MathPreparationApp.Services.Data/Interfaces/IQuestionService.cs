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

        Task<IQueryable<Question>> GetNotAnsweredBeforeQuestionsAsync(string userId, IQueryable<Question> questionsQuery);
        Task<IQueryable<Question>> GetNeverAnsweredCorrectlyQuestionsAsync(string userId, IQueryable<Question> questionsQuery);

        Task<int> GetQuestionCountBySubjectIdAsync(int subjectId);
        Task<int> GetQuestionCountByTopicIdAsync(int topicId);
        Task<int> GetNotAnsweredBeforeQuestionCountAsync(int subjectId, int topicId, string userId);
        Task<int> GetNeverAnsweredCorrectlyQuestionCountAsync(int subjectId, int topicId, string userId);

        Task<bool> WasTheQuestionAnsweredCorrectly(Guid questionId, string userId);
        Task UpdateAnsweredCorrectlyColumn(Guid questionId, string userId);
    }
}
