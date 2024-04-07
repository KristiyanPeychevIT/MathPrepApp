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
        [Display(Name = "Question Name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Answer")]
        public string CorrectOption { get; set; } = null!;

        [Display(Name = "Points")]
        public int Points { get; set; }

        [Display(Name = "Image")]
        public byte[]? ImageBytes { get; set; }

        [Display(Name = "Explanation")]
        public string Solution { get; set; } = null!;

        [Display(Name = "Subject")] 
        public int SubjectId { get; set; }

        [Display(Name = "Topic")]
        public int TopicId { get; set; }
    }
}
