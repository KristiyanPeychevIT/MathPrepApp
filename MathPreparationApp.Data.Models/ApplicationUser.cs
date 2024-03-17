namespace MathPreparationApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.AnsweredQuestions = new HashSet<Question>();
            this.UserAnsweredQuestions = new HashSet<UserAnsweredQuestion>();
        }

        public virtual ICollection<Question> AnsweredQuestions { get; set; }
        public virtual ICollection<UserAnsweredQuestion> UserAnsweredQuestions { get; set; }
    }
}
