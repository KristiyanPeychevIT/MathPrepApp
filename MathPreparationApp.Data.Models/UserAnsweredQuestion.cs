using System.ComponentModel.DataAnnotations;

namespace MathPreparationApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserAnsweredQuestion
    {
        public Guid UserId { get; set; }
        public int QuestionId { get; set; }

        public ApplicationUser User { get; set; } = null!;
        public Question Question { get; set; } = null!;

        [Required]
        public bool AnsweredCorrectly { get; set; }
    }
}
