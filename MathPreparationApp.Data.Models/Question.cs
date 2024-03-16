namespace MathPreparationApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class Question
    {
        public Question()
        {
            this.Id = new Guid();
            this.UsersAnswered = new HashSet<ApplicationUser>();
            this.UserAnsweredQuestions = new HashSet<UserAnsweredQuestion>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Option1 { get; set; } = null!;

        [Required]
        public string Option2 { get; set; } = null!;

        [Required]
        public string Option3 { get; set; } = null!;

        [Required]
        public string Option4 { get; set; } = null!;

        [Required]
        public string CorrectOption { get; set; } = null!;

        public byte[]? ImageBytes { get; set; }

        [Required]
        public string Solution { get; set;  } = null!;

        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; } = null!;

        public int? TopicId { get; set; }

        public virtual Topic? Topic { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<ApplicationUser> UsersAnswered { get; set; }

        public virtual ICollection<UserAnsweredQuestion> UserAnsweredQuestions { get; set; }
    }
}