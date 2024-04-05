using MathPreparationApp.Data;
using MathPreparationApp.Data.Models;

namespace MathPreparationApp.Services.Data
{
    using MathPreparationApp.Services.Data.Interfaces;
    using MathPreparationApp.Web.ViewModels.Question;
    using System.Threading.Tasks;

    public class QuestionService : IQuestionService
    {
        private readonly MathPreparationAppDbContext dbContext;

        public QuestionService(MathPreparationAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(QuestionFormModel formModel)
        {
            Question question = new Question
            {
                Name = formModel.Name,
                Option1 = formModel.Option1,
                Option2 = formModel.Option2,
                Option3 = formModel.Option3,
                Option4 = formModel.Option4,
                CorrectOption = formModel.CorrectOption,
                Points = formModel.Points,
                ImageBytes = formModel.ImageBytes,
                Solution = formModel.Solution,
                SubjectId = formModel.SubjectId,
                TopicId = formModel.TopicId,
            };

            await this.dbContext.Questions.AddAsync(question);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
