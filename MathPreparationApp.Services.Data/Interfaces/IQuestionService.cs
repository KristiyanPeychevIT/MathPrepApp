namespace MathPreparationApp.Services.Data.Interfaces
{
    using Web.ViewModels.Question;

    public interface IQuestionService
    {
        Task AddAsync(QuestionFormModel formModel);
    }
}
