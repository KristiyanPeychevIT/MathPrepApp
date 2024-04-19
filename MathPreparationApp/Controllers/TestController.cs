namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Test;
    using MathPreparationApp.Services.Data.Models.Question;

    public class TestController : Controller
    {
        private readonly IQuestionService questionService;
        private readonly ISubjectService subjectService;
        private readonly ITestService testService;

        public TestController(IQuestionService questionService, ISubjectService subjectService, ITestService testService)
        {
            this.questionService = questionService;
            this.subjectService = subjectService;
            this.testService = testService;
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

        public async Task<IActionResult> Create([FromForm]TestFormModel formModel)
        {
            AllQuestionsFilteredServiceModel serviceModel =
                await this.testService.AllAsync(formModel);

            formModel.Questions = serviceModel.Questions;
            formModel.QuestionCount = serviceModel.TotalQuestionsCount;

            return View("Take", formModel);
        }

        [HttpGet]
        public async Task<IActionResult> Take()
        {
            return View();
        }
    }
}
