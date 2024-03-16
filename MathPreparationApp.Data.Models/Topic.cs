namespace MathPreparationApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MathPreparationApp.Common.EntityValidationConstants.Topic;

    public class Topic
    {
        public Topic()
        {
            this.Questions = new HashSet<Question>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength), MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }

    }
}
