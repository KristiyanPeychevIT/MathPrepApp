using System.Runtime.CompilerServices;
using MathPreparationApp.Web.ViewModels.Question;
using Microsoft.EntityFrameworkCore;

namespace MathPreparationApp.Services.Data
{
    using System.Threading.Tasks;
    using System;
    using System.Linq;

    using Interfaces;
    using MathPreparationApp.Data;
    using MathPreparationApp.Data.Models;
    using Models.Question;
    using Web.ViewModels.Test;
    using Web.ViewModels.Question.Enums;


    public class TestService : ITestService
    {
        private readonly MathPreparationAppDbContext dbContext;
        private readonly IQuestionService questionService;
        private readonly Random _random;

        public TestService(MathPreparationAppDbContext dbContext, IQuestionService questionService)
        {
            this.dbContext = dbContext;
            this.questionService = questionService;

            _random = new Random();
        }
        public async Task<AllQuestionsFilteredServiceModel> AllAsync(TestFormModel queryModel)
        {
            IQueryable<Question> questionsQuery = this.dbContext
                .Questions
                .Where(q => q.IsActive)
                .AsQueryable();

            questionsQuery = questionsQuery
                .Where(q => q.SubjectId == queryModel.SubjectId);

            if (queryModel.TopicId != null)
            {
                questionsQuery = questionsQuery
                    .Where(q => q.TopicId == queryModel.TopicId);
            }

            questionsQuery = queryModel.CategoryOfQuestion switch
            {
                CategoryOfQuestions.All => questionsQuery, //Takes all the questions, regardless whether they were answered correctly or incorrectly, or never answered before
                CategoryOfQuestions.NotAnsweredBefore => await questionService.GetNotAnsweredBeforeQuestionsAsync(),
                CategoryOfQuestions.NeverAnsweredCorrectly => await questionService.GetNeverAnsweredCorrectlyQuestionsAsync()
            };

            questionsQuery = Shuffle(questionsQuery.ToList())
                .Take(queryModel.NumberOfQuestions);
            
            questionsQuery = queryModel.SortQuestions switch
            {
                SortQuestions.Randomly => questionsQuery, // The questions are already randomized here
                SortQuestions.NewestFirst => questionsQuery
                    .OrderByDescending(q => q.AddedOn),
                SortQuestions.OldestFirst => questionsQuery
                    .OrderBy(q => q.AddedOn)
            };

            IEnumerable<QuestionTestViewModel> allQuestions = questionsQuery
                .Select(q => new QuestionTestViewModel()
                {
                    Id = q.Id.ToString(),
                    Name = q.Name,
                    Option1 = q.Option1,
                    Option2 = q.Option2,
                    Option3 = q.Option3,
                    Option4 = q.Option4,
                    CorrectOption = q.CorrectOption,
                    Points = q.Points,
                    ImageBytes = q.ImageBytes,
                    Solution = q.Solution,
                    SubjectId = q.SubjectId,
                    TopicId = q.TopicId,
                })
                .ToArray();

            int totalQuestions = questionsQuery.Count();

            return new AllQuestionsFilteredServiceModel()
            {
                TotalQuestionsCount = totalQuestions,
                Questions = allQuestions
            };
        }

        public async Task<IEnumerable<QuestionTestViewModel>> GetQuestionsByIdsAsync(Guid[] questionIds)
        {
            IEnumerable<QuestionTestViewModel> questions = await this.dbContext
                .Questions
                .Where(q => questionIds.Contains(q.Id))
                .Select(q => new QuestionTestViewModel
                {
                    Id = q.Id.ToString(),
                    Name = q.Name,
                    Option1 = q.Option1,
                    Option2 = q.Option2,
                    Option3 = q.Option3,
                    Option4 = q.Option4,
                    CorrectOption = q.CorrectOption,
                    Points = q.Points,
                    ImageBytes = q.ImageBytes,
                    Solution = q.Solution,
                    SubjectId = q.SubjectId,
                    TopicId = q.TopicId,

                })
                .ToArrayAsync();

            return questions;
        }

        private IQueryable<T> Shuffle<T>(List<T> list)
        {
            // Fisher-Yates shuffle algorithm
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                T value = list[k]!;
                list[k] = list[n]!;
                list[n] = value;
            }
            return list.AsQueryable();
        }
    }
}
