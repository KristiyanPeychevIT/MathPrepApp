namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Test;
    using ViewModels.Question.Enums;

    public class TestController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly IQuestionService questionService;

        public TestController(IQuestionService questionService, ISubjectService subjectService)
        {
            this.questionService = questionService;
            this.subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TestFormModel formModel = new TestFormModel()
            {
                Subjects = await this.subjectService.AllSubjectsAsync(),
            };
            return this.View(formModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(TestFormModel formModel)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
