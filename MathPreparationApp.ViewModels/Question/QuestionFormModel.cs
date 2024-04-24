namespace MathPreparationApp.Web.ViewModels.Question
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Subject;
    using Topic;
    using static Infrastructure.Extensions.ValidationAttributeExtensions;
    using static MathPreparationApp.Common.EntityValidationConstants.Question;

    public class QuestionFormModel
    {
        public QuestionFormModel()
        {
            this.Subjects = new HashSet<SubjectViewModel>();
            this.Topics = new HashSet<TopicViewModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(OptionMaxLength)]
        public string Option1 { get; set; } = null!;

        [Required]
        [StringLength(OptionMaxLength)]
        public string Option2 { get; set; } = null!;

        [Required]
        [StringLength(OptionMaxLength)]
        public string Option3 { get; set; } = null!;

        [Required]
        [StringLength(OptionMaxLength)]
        public string Option4 { get; set; } = null!;

        [Required]
        [StringLength(OptionMaxLength)]
        [Display(Name = "Правилен отговор")]
        public string CorrectOption { get; set; } = null!;

        [Required]
        [Range(typeof(int), PointsMinValue, PointsMaxValue)]
        public int Points { get; set; }

        [ImageMaxSize]
        [Display(Name = "Чертеж")]
        public byte[]? ImageBytes { get; set; }

        [Required]
        [StringLength(SolutionMaxLength, MinimumLength = SolutionMinLength)]
        [Display(Name = "Обяснение")]
        public string Solution { get; set; } = null!;

        [Display(Name = "Раздел")]
        public int SubjectId { get; set; }

        [Display(Name = "Подраздел")]
        public int TopicId { get; set; }

        public IEnumerable<SubjectViewModel> Subjects { get; set; }
        public IEnumerable<TopicViewModel> Topics { get; set; }
    }
}
