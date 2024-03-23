namespace MathPreparationApp.Services.Data.Interfaces
{
    using Web.ViewModels.Topic;
    public interface ITopicService
    {
        Task<bool> TopicExistsByIdAsync(int id);
        Task<bool> TopicExistsByNameAsync(string name);

        Task CreateAsync(TopicFormModel formModel);
    }
}
