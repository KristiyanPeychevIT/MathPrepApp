namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Question;
    using MathPreparationApp.Web.ViewModels.Topic;

    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly IQuestionService questionService;

        public QuestionController(ISubjectService subjectService, IQuestionService questionService)
        {
            this.subjectService = subjectService;
            this.questionService = questionService;
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

        //[HttpPost]

        //public async Task<IActionResult> Add(QuestionFormModel model)
        //{
        //    bool subjectExists =
        //        await this.subjectService.SubjectExistsByIdAsync(model.SubjectId);

        //    if (!subjectExists)
        //    {
        //        ModelState.AddModelError(nameof(model.SubjectId), "Selected subject does not exist!");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        model.Subjects = await this.subjectService.AllSubjectsAsync();

        //        return this.View(model);
        //    }

        //    try
        //    {
        //        //await this.questionService.CreateAsync(model);
        //    }
        //    catch (Exception)
        //    {
        //        this.ModelState.AddModelError(string.Empty, "Unexpected error occured while adding a topic!");
        //        model.Subjects = await this.subjectService.AllSubjectsAsync();

        //        return this.View(model);
        //    }

        //    return this.RedirectToAction("Index", "Home");
        //}
    }
}
