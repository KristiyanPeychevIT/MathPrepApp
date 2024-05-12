namespace MathPreparationApp.Web.ViewModels.Test
{
    using System.ComponentModel.DataAnnotations;

    using Question;
    using Question.Enums;
    using Subject;
    using Topic;
    public class TestFormModel
    {
        public TestFormModel()
        {
            this.Subjects = new HashSet<SubjectViewModel>();
            this.Topics = new HashSet<TopicViewModel>();

            this.Questions = new HashSet<QuestionTestViewModel>();
        }

        [Display(Name = "Раздел")]
        [Required(ErrorMessage = "Моля, изберете раздел от възможните опции.")]
        public int SubjectId { get; set; }

        [Display(Name = "Подраздел")]
        public int? TopicId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Минималният брой въпроси е 1.")]
        public int NumberOfQuestions { get; set; }

        public CategoryOfQuestions CategoryOfQuestion { get; set; }

        //public ShowAnswers ShowAnswers { get; set; }
        public SortQuestions SortQuestions { get; set; }

        public int QuestionCount { get; set; }

        public IEnumerable<SubjectViewModel> Subjects { get; set; }
        public IEnumerable<TopicViewModel> Topics { get; set; }

        public IEnumerable<QuestionTestViewModel> Questions { get; set; }
    }
}
