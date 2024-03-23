using MathPreparationApp.Data.Models;

namespace MathPreparationApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using MathPreparationApp.Data;
    using Interfaces;
    using Web.ViewModels.Topic;
    public class TopicService : ITopicService
    {
        private readonly MathPreparationAppDbContext dbContext;

        public TopicService(MathPreparationAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> TopicExistsByIdAsync(int id)
        {
            return await dbContext.Topics.AnyAsync(t => t.Id == id);
        }

        public async Task<bool> TopicExistsByNameAsync(string name)
        {
            return await dbContext.Topics.AnyAsync(t => t.Name == name);
        }

        public async Task CreateAsync(TopicFormModel formModel)
        {
            Topic topic = new Topic
            {
                Id = formModel.Id,
                Name = formModel.Name,
                SubjectId = formModel.SubjectId,
            };

            await this.dbContext.Topics.AddAsync(topic);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
