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
        private readonly ITopicService topicService;

        public TopicController(ISubjectService subjectService, ITopicService topicService)
        {
            this.subjectService = subjectService;
            this.topicService = topicService;
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

        [HttpPost]

        public async Task<IActionResult> Add(TopicFormModel model)
        {
            bool subjectExists = 
                await this.subjectService.SubjectExistsByIdAsync(model.SubjectId);

            if (!subjectExists)
            {
                ModelState.AddModelError(nameof(model.SubjectId), "Selected subject does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Subjects = await this.subjectService.AllSubjectsAsync();

                return this.View(model);
            }

            try
            {
                await this.topicService.CreateAsync(model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,"Unexpected error occured while adding a topic!");
                model.Subjects = await this.subjectService.AllSubjectsAsync();

                return this.View(model);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
