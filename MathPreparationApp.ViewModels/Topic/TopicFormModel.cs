namespace MathPreparationApp.Web.ViewModels.Topic
{
    using static Common.EntityValidationConstants.Topic;
    using System.ComponentModel.DataAnnotations;

    public class TopicFormModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength), MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        public int SubjectId { get; set; }
        
        //Needs to be finished
        //Collection should be of type SubjectViewModel - displaying all the added subjects
        //public virtual ICollection<Question>? Questions { get; set; }
    }
}
