namespace MathPreparationApp.Web.ViewModels.Test
{
    using MathPreparationApp.Web.ViewModels.Question;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FeedbackViewModel
    {
        public int Score { get; set; }
        public IEnumerable<QuestionTestViewModel> Questions { get; set; } = null!;

        public Dictionary<Guid, int> SelectedOptions { get; set; } = null!;
    }
}
