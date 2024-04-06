using System.Runtime.CompilerServices;

namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Question;
    using MathPreparationApp.Web.ViewModels.Topic;
    using static System.Net.Mime.MediaTypeNames;

    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly ITopicService topicService;
        private readonly IQuestionService questionService;

        public QuestionController(ISubjectService subjectService, IQuestionService questionService, ITopicService topicService)
        {
            this.subjectService = subjectService;
            this.questionService = questionService;
            this.topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            QuestionFormModel formModel = new QuestionFormModel()
            {
                Subjects = await this.subjectService.AllSubjectsAsync()
            };

            return View(formModel);
        }

        [HttpPost]

        public async Task<IActionResult> Add(QuestionFormModel model, [FromForm] IFormFile? imageFile)
        {
            bool subjectExists =
                await this.subjectService.SubjectExistsByIdAsync(model.SubjectId);
            bool topicExists =
                await this.topicService.TopicExistsByIdAsync(model.TopicId);

            if (!subjectExists)
            {
                ModelState.AddModelError(nameof(model.SubjectId), "Selected subject does not exist!");
            }
            if (!topicExists)
            {
                ModelState.AddModelError(nameof(model.TopicId), "Selected topic does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Subjects = await this.subjectService.AllSubjectsAsync();

                return this.View(model);
            }

            if (imageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    model.ImageBytes = memoryStream.ToArray();
                }
            }
            try
            {
                await this.questionService.AddAsync(model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while adding a question!");
                model.Subjects = await this.subjectService.AllSubjectsAsync();

                return this.View(model);
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public async Task<IActionResult> Edit(string id)
        {
            bool questionExists = await this.questionService.QuestionExistsByIdAsync(id);

            if (!questionExists)
            {
                return BadRequest();
            }

            try
            {
                QuestionEditFormModel formModel = await this.questionService
                    .GetQuestionByIdAsync(id);
                formModel.Subjects = await this.subjectService.AllSubjectsAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected error occured while trying to retrieve question with the provided questionId!");
            }
        }

        [HttpPost]

        public async Task<IActionResult> Edit(string id, QuestionEditFormModel model, [FromForm] IFormFile? imageFile)
        {
            if (!this.ModelState.IsValid)
            {
                model.Subjects = await this.subjectService.AllSubjectsAsync();

                return this.View(model);
            }

            bool questionExists = await this.questionService.QuestionExistsByIdAsync(id);

            if (!questionExists)
            {
                return BadRequest();
            }

            if (model.RemoveImage)
            {
                model.ImageBytes = null;
            }
            else if (imageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    model.ImageBytes = memoryStream.ToArray();
                }
            }

            try
            {
                await this.questionService.EditAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to edit the question!");

                model.Subjects = await this.subjectService.AllSubjectsAsync();
                return this.View(model);
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> OnGetTopics(int subjectId)
        {
            try
            {
                IEnumerable<TopicViewModel> topics = await this.topicService.AllTopicsBySubjectIdAsync(subjectId);

                return Json(topics);
            }
            catch (Exception)
            {
                throw new Exception( "Topics with the provided subjectId cannot be retrieved!");
            }
        }
    }
}
