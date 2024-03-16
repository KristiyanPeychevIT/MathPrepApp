namespace MathPreparationApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; } = null!;

        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
