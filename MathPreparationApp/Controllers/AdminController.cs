namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;

    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IQuestionService questionService;
        private readonly ISubjectService subjectService;
        private readonly ITopicService topicService;

        public AdminController(IQuestionService questionService, ISubjectService subjectService, ITopicService topicService)
        {
            this.questionService = questionService;
            this.subjectService = subjectService;
            this.topicService = topicService;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await questionService.AllQuestionsAsync();
            return View(questions);
        }

        public async Task<IActionResult> GetQuestions()
        {
            var questions = await questionService.AllQuestionsAsync();
            return PartialView("_QuestionsPartial", questions);
        }

        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await subjectService.AllSubjectsAsync();
            return PartialView("_SubjectsPartial", subjects);
        }

        public async Task<IActionResult> GetTopics()
        {
            var topics = await topicService.AllTopicsAsync();
            return PartialView("_TopicsPartial", topics);
        }
    }
}
