namespace MathPreparationApp.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using Models.Question;
    using Web.ViewModels.Test;
    using Web.ViewModels.Question;

    public interface ITestService
    {
        Task<AllQuestionsFilteredServiceModel> AllAsync(TestFormModel queryModel);

        Task<IEnumerable<QuestionTestViewModel>> GetQuestionsByIdsAsync(Guid[] questionIds);
    }
}
