namespace MathPreparationApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserAnsweredQuestion
    {
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }

        public ApplicationUser User { get; set; } = null!;
        public Question Question { get; set; } = null!;

        [Required]
        public bool AnsweredCorrectly { get; set; }
    }
}
