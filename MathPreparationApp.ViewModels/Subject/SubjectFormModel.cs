namespace MathPreparationApp.Web.ViewModels.Subject
{
    using static Common.EntityValidationConstants.Subject;
    using System.ComponentModel.DataAnnotations;

    public class SubjectFormModel
    {
        [Required]
        [Display(Name = "Раздел Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength), MinLength(NameMinLength)]
        [Display(Name = "Раздел")]
        public string Name { get; set; } = null!;
    }
}
