namespace MathPreparationApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.AnsweredQuestions = new HashSet<UserAnsweredQuestion>();
        }

        public virtual ICollection<UserAnsweredQuestion> AnsweredQuestions { get; set; }
    }
}
