namespace MathPreparationApp.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MathPreparationApp.Data;
    using MathPreparationApp.Data.Models;
    using Interfaces;
    using Web.ViewModels.Question;
    using MathPreparationApp.Web.ViewModels.Topic;

    
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
        public async Task<bool> QuestionExistsByIdAsync(string questionId)
        {
            return await dbContext
                .Questions
                .Where(q => q.IsActive)
                .AnyAsync(q => q.Id.ToString() == questionId);
        }

        public async Task<QuestionEditFormModel> GetQuestionByIdAsync(string questionId)
        {
            Question question = await this.dbContext
                .Questions
                .Include(q => q.Subject)
                .Include(q => q.Topic)
                .Where(q => q.IsActive)
                .FirstAsync(q => q.Id.ToString() == questionId);

            return new QuestionEditFormModel
            {
                Name = question.Name,
                Option1 = question.Option1,
                Option2 = question.Option2,
                Option3 = question.Option3,
                Option4 = question.Option4,
                CorrectOption = question.CorrectOption,
                Points = question.Points,
                ImageBytes = question.ImageBytes,
                Solution = question.Solution,
                SubjectId = question.SubjectId,
                TopicId = question.TopicId
            };
        }

        public async Task<QuestionDeleteViewModel> GetQuestionForDeleteByIdAsync(string questionId)
        {
            Question question = await this.dbContext
                .Questions
                .Where(q => q.IsActive)
                .FirstAsync(q => q.Id.ToString() == questionId);

            return new QuestionDeleteViewModel()
            {
                Name = question.Name,
                CorrectOption = question.CorrectOption,
                Points = question.Points,
                ImageBytes = question.ImageBytes,
                Solution = question.Solution,
                SubjectId = question.SubjectId,
                TopicId = question.TopicId
            };
        }

        public async Task EditAsync(string questionId, QuestionEditFormModel formModel)
        {
            Question question = await this.dbContext
                .Questions
                .Where(q => q.IsActive)
                .FirstAsync(q => q.Id.ToString() == questionId);


            question.Name = formModel.Name;
            question.Option1 = formModel.Option1;
            question.Option2 = formModel.Option2;
            question.Option3 = formModel.Option3;
            question.Option4 = formModel.Option4;
            question.CorrectOption = formModel.CorrectOption;
            question.Points = formModel.Points;
            question.ImageBytes = formModel.ImageBytes;
            question.Solution = formModel.Solution;
            question.SubjectId = formModel.SubjectId;
            question.TopicId = formModel.TopicId;
            question.UpdatedOn = DateTime.Now;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string questionId)
        {
            Question questionToDelete = await this.dbContext
                .Questions
                .Where(q => q.IsActive)
                .FirstAsync(q => q.Id.ToString() == questionId);

            questionToDelete.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
