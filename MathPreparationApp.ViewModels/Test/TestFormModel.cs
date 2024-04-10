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

            this.Questions = new HashSet<QuestionFormModel>();
        }

        [Display(Name = "Subject")]
        public int SubjectId { get; set; }

        [Display(Name = "Topic")]
        public int TopicId { get; set; }

        public int NumberOfQuestions { get; set; }

        public CategoryOfQuestions CategoryOfQuestion { get; set; }
        public ShowAnswers ShowAnswers { get; set; }
        public SortQuestions SortQuestions { get; set; }

        public int QuestionCount { get; set; }

        public IEnumerable<SubjectViewModel> Subjects { get; set; }
        public IEnumerable<TopicViewModel> Topics { get; set; }

        public IEnumerable<QuestionFormModel> Questions { get; set; }
    }
}
