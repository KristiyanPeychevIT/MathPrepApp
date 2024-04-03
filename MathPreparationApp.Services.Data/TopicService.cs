namespace MathPreparationApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using MathPreparationApp.Data;
    using Interfaces;
    using Web.ViewModels.Topic;
    using System.Collections.Generic;
    using MathPreparationApp.Data.Models;
    using MathPreparationApp.Web.ViewModels.Subject;

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

        public async Task EditAsync(int id, TopicFormModel editedFormModel)
        {
            Topic topicToEdit = await this.dbContext
                .Topics
                .FirstAsync(t => t.Id == id);

            topicToEdit.Name = editedFormModel.Name;
            topicToEdit.SubjectId = editedFormModel.SubjectId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TopicViewModel viewModel)
        {
            Topic topicToDelete = await this.dbContext
                .Topics
                .FirstAsync(t => t.Id == viewModel.Id);

            this.dbContext.Topics.Remove(topicToDelete);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            Topic topic = await this.dbContext
                .Topics.FirstAsync(t => t.Id == id);

            return topic;
        }

        public async Task<IEnumerable<TopicViewModel>> AllTopicsBySubjectIdAsync(int subjectId)
        {
            IEnumerable<TopicViewModel> allTopics = await this.dbContext
                .Topics
                .AsNoTracking()
                .Where(t => t.SubjectId == subjectId)
                .Select(t => new TopicViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToArrayAsync();

            return allTopics;
        }
    }
}
