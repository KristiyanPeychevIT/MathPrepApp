﻿namespace MathPreparationApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static MathPreparationApp.Common.EntityValidationConstants.Question;

    public class Question
    {
        public Question()
        {
            this.Id = Guid.NewGuid();
            this.UsersAnswered = new HashSet<ApplicationUser>();
            this.UserAnsweredQuestions = new HashSet<UserAnsweredQuestion>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength), MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(OptionMaxLength)]
        public string Option1 { get; set; } = null!;

        [Required]
        [MaxLength(OptionMaxLength)]
        public string Option2 { get; set; } = null!;

        [Required]
        [MaxLength(OptionMaxLength)]
        public string Option3 { get; set; } = null!;

        [Required]
        [MaxLength(OptionMaxLength)]
        public string Option4 { get; set; } = null!;

        [Required]
        [MaxLength(OptionMaxLength)]
        public string CorrectOption { get; set; } = null!;

        [Required]
        public int Points { get; set; }

        public byte[]? ImageBytes { get; set; }

        [Required]
        [MaxLength(SolutionMaxLength), MinLength(SolutionMinLength)]
        public string Solution { get; set;  } = null!;

        public bool IsActive { get; set; }

        public int SubjectId { get; set; }
         
        public virtual Subject Subject { get; set; } = null!;

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; } = null!;

        public DateTime AddedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<ApplicationUser>? UsersAnswered { get; set; }

        public virtual ICollection<UserAnsweredQuestion>? UserAnsweredQuestions { get; set; }
    }
}