namespace MathPreparationApp.Web.ViewModels.Topic
{
    using static Common.EntityValidationConstants.Topic;
    using System.ComponentModel.DataAnnotations;
    using Subject;

    public class TopicFormModel
    {
        public TopicFormModel()
        {
            this.Subjects = new HashSet<SubjectViewModel>();
        }
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength), MinLength(NameMinLength)]
        [Display(Name = "Подраздел")]
        public string Name { get; set; } = null!;

        [Display(Name = "Раздел")]
        public int SubjectId { get; set; }

        public IEnumerable<SubjectViewModel> Subjects { get; set; }
    }
}
