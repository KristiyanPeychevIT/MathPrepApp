namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Test;
    using MathPreparationApp.Services.Data.Models.Question;
    using MathPreparationApp.Web.ViewModels.Question;
    using System.Text.Json;

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

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var formModelJson = JsonSerializer.Serialize(formModel, jsonSerializerOptions);
            HttpContext.Session.SetString("FormModel", formModelJson);
            return RedirectToAction("Take", "Test");
        }

        [HttpGet]
        public async Task<IActionResult> Take()
        {
            var formModelJson = HttpContext.Session.GetString("FormModel");
            if (formModelJson == null)
            {
                // Handle case where formModel is not found
                return RedirectToAction("Create");
            }

            var formModel = JsonSerializer.Deserialize<TestFormModel>(formModelJson);
            return this.View(formModel);
        }
    }
}
