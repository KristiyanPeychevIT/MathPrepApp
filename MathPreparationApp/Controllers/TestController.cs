namespace MathPreparationApp.Web.Controllers
{
    using System.Text.Json;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using MathPreparationApp.Services.Data.Models.Question;
    using MathPreparationApp.Web.Infrastructure.Extensions;
    using MathPreparationApp.Web.ViewModels.Question;
    using Newtonsoft.Json;
    using ViewModels.Test;

    [Authorize]
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
            string currentUserId = this.User.GetId()!;

            AllQuestionsFilteredServiceModel serviceModel =
                await this.testService.AllAsync(formModel, currentUserId);

            formModel.Questions = serviceModel.Questions;
            formModel.QuestionCount = serviceModel.TotalQuestionsCount;

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var formModelJson = System.Text.Json.JsonSerializer.Serialize(formModel, jsonSerializerOptions);
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

            var formModel = System.Text.Json.JsonSerializer.Deserialize<TestFormModel>(formModelJson);
            return this.View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(string selections)
        {
            string currentUserId = this.User.GetId()!;

            Dictionary<Guid, int> selectedOptions = JsonConvert.DeserializeObject<Dictionary<Guid, int>>(selections)!; //Gets the QuestionIds of the questions in the test and the index of the selected option for each Question

            int score = await this.testService.CheckAndSubmitAnswersAsync(selectedOptions, currentUserId);

            Guid[] questionIds = selectedOptions.Keys.ToArray();
            // Get the questions corresponding to the question IDs
            IEnumerable<QuestionTestViewModel> questions = await this.testService.GetQuestionsByIdsAsync(questionIds, selectedOptions);

            FeedbackViewModel viewModel = new FeedbackViewModel()
            {
                Score = score,
                Questions = questions,
                SelectedOptions = selectedOptions
            };
            return View(viewModel);
        }
    }
}
