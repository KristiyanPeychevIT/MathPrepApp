namespace MathPreparationApp.Services.Data.Models.Question
{
    using MathPreparationApp.Web.ViewModels.Question;
    public class AllQuestionsFilteredServiceModel
    {
        public AllQuestionsFilteredServiceModel()
        {
            this.Questions = new HashSet<QuestionTestViewModel>();
        }

        public int TotalQuestionsCount { get; set; }

        public IEnumerable<QuestionTestViewModel> Questions { get; set; }
    }
}
