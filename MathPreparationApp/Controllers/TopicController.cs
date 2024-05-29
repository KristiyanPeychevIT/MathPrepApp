namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Topic;
    using Topic = Data.Models.Topic;
    using static Common.GeneralApplicationConstants;

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
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add()
        {
            TopicFormModel formModel = new TopicFormModel()
            {
                Subjects = await this.subjectService.AllSubjectsAsync()
            };

            return View(formModel);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
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

            return this.RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            Topic topic = await this.topicService.GetTopicByIdAsync(id);

            if (topic == null)
            {
                return BadRequest();
            }

            TopicFormModel model = new TopicFormModel()
            {
                Name = topic.Name,
                SubjectId = topic.SubjectId,
                Subjects = await this.subjectService.AllSubjectsAsync()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id, TopicFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Subjects = await this.subjectService.AllSubjectsAsync();
                return this.View(model);
            }

            try
            {
                await this.topicService.EditAsync(id, model);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected error occured while editing a topic!");
            }

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            Topic topic = await this.topicService.GetTopicByIdAsync(id);

            if (topic == null)
            {
                return BadRequest();
            }

            string subjectName;

            try
            {
                subjectName = await this.subjectService.GetSubjectNameByIdAsync(topic.SubjectId);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while retrieving subject name for current topic!");
                return this.RedirectToAction("Index", "Admin");
            }

            TopicViewModel model = new TopicViewModel()
            {
                Id = topic.Id,
                Name = topic.Name,
                SubjectName = subjectName
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(TopicViewModel model)
        {
            try
            {
                await this.topicService.DeleteAsync(model);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected error occured while deleting a topic!");
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}
