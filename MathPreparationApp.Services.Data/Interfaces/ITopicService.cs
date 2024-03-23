namespace MathPreparationApp.Services.Data.Interfaces
{
    using MathPreparationApp.Data.Models;
    using Web.ViewModels.Topic;
    public interface ITopicService
    {
        Task<bool> TopicExistsByIdAsync(int id);
        Task<bool> TopicExistsByNameAsync(string name);

        Task CreateAsync(TopicFormModel formModel);

        Task<Topic> GetTopicByIdAsync(int id);
        Task EditAsync(int id, TopicFormModel formModel);
        Task DeleteAsync(TopicViewModel viewModel);
    }
}
