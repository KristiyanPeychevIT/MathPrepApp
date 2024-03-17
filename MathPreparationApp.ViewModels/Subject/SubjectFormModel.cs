namespace MathPreparationApp.Web.ViewModels.Subject
{
    using static Common.EntityValidationConstants.Subject;
    using System.ComponentModel.DataAnnotations;

    public class SubjectFormModel
    {
        [Required]
        [Display(Name = "Subject Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength), MinLength(NameMinLength)]
        [Display(Name = "Subject Name")]
        public string Name { get; set; } = null!;
    }
}
