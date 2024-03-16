namespace MathPreparationApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MathPreparationApp.Common.EntityValidationConstants.Subject;

    public class Subject
    {
        public Subject()
        {
            this.Topics = new HashSet<Topic>();
            this.Questions = new HashSet<Question>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength), MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
