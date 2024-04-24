namespace MathPreparationApp.Web.ViewModels.Question
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class QuestionDeleteViewModel
    {
        [Display(Name = "Условие на въпроса")]
        public string Name { get; set; } = null!;

        [Display(Name = "Отговор")]
        public string CorrectOption { get; set; } = null!;

        [Display(Name = "Точки")]
        public int Points { get; set; }

        [Display(Name = "Чертеж")]
        public byte[]? ImageBytes { get; set; }

        [Display(Name = "Обяснение")]
        public string Solution { get; set; } = null!;

        [Display(Name = "Раздел")] 
        public int SubjectId { get; set; }

        [Display(Name = "Подраздел")]
        public int TopicId { get; set; }
    }
}
