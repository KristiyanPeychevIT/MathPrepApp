namespace MathPreparationApp.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using Models.Question;
    using Web.ViewModels.Test;
    using Web.ViewModels.Question;

    public interface ITestService
    {
        Task<AllQuestionsFilteredServiceModel> AllAsync(TestFormModel queryModel, string userId);

        Task<IEnumerable<QuestionTestViewModel>> GetQuestionsByIdsAsync(Guid[] questionIds, Dictionary<Guid, int> originalOrder);

        Task<int> CheckAndSubmitAnswersAsync(Dictionary<Guid, int> selections, string userId);
    }
}
