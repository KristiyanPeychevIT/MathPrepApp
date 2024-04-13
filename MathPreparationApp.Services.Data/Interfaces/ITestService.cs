namespace MathPreparationApp.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using Models.Question;
    using Web.ViewModels.Test;

    public interface ITestService
    {
        Task<AllQuestionsFilteredServiceModel> AllAsync(TestFormModel queryModel);
    }
}
