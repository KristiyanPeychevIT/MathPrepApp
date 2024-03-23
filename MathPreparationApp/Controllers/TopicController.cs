namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Topic;

    [Authorize]
    public class TopicController : Controller
    {
        private readonly ISubjectService subjectService;

        public TopicController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            TopicFormModel formModel = new TopicFormModel()
            {
                Subjects = await this.subjectService.AllSubjectsAsync()
            };

            return View(formModel);
        }


    }
}
