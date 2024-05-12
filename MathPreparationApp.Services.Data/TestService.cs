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
    using static System.Formats.Asn1.AsnWriter;


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
        public async Task<AllQuestionsFilteredServiceModel> AllAsync(TestFormModel queryModel, string userId)
        {
            IQueryable<Question> questionsQuery = this.dbContext
                .Questions
                .Where(q => q.IsActive)
                .AsQueryable();

            questionsQuery = questionsQuery
                .Where(q => q.SubjectId == queryModel.SubjectId);

            // Check if the selected topic is "All" (or any value that represents selecting all topics)
            if (queryModel.TopicId != 0)
            {
                questionsQuery = questionsQuery
                    .Where(q => q.TopicId == queryModel.TopicId);
            }

            questionsQuery = queryModel.CategoryOfQuestion switch
            {
                CategoryOfQuestions.All => questionsQuery, //Takes all the questions, regardless whether they were answered correctly or incorrectly, or never answered before
                CategoryOfQuestions.NotAnsweredBefore => await questionService.GetNotAnsweredBeforeQuestionsAsync(userId, questionsQuery),
                CategoryOfQuestions.NeverAnsweredCorrectly => await questionService.GetNeverAnsweredCorrectlyQuestionsAsync(userId, questionsQuery)
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

        public async Task<IEnumerable<QuestionTestViewModel>> GetQuestionsByIdsAsync(Guid[] questionIds, Dictionary<Guid, int> originalOrder)
        {
            var questions = await this.dbContext
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
                    TopicId = q.TopicId
                })
                .ToListAsync();

            // Order questions based on the values in the originalOrder dictionary

            List<QuestionTestViewModel> orderedQuestions = new List<QuestionTestViewModel>();
            foreach (var kvp in originalOrder)
            {
                var question = questions.FirstOrDefault(q => q.Id.ToLower() == kvp.Key.ToString());
                if (question != null)
                {
                    orderedQuestions.Add(question);
                }
            }

            return orderedQuestions;
        }

        public async Task<int> CheckAndSubmitAnswersAsync(Dictionary<Guid, int> selections, string userId)
        {
            List<Question> questions = await dbContext
                .Questions
                .Where(q => selections.Keys.Contains(q.Id))
                .ToListAsync();

            // Dictionary to store question IDs and whether the answers are correct (true/false)
            var answerResults = new Dictionary<Guid, bool>();

            foreach (Question question in questions)
            {
                // Get the selected option index for the current question
                int selectedOptionIndex = selections[question.Id];

                string selectedOption;

                switch (selectedOptionIndex)
                {
                    case 0:
                        selectedOption = question.Option1;
                        break;
                    case 1:
                        selectedOption = question.Option2;
                        break;
                    case 2:
                        selectedOption = question.Option3;
                        break;
                    case 3:
                        selectedOption = question.Option4;
                        break;
                    default:
                        selectedOption = "Invalid Option";
                        break;
                }
                // Check if the selected option index matches the correct option index
                bool isCorrect = selectedOption == question.CorrectOption;

                // Add the question ID and the correctness of the answer to the result dictionary
                answerResults.Add(question.Id, isCorrect);

                bool questionHasBeenAnsweredByTheCurrentUser = await HasTheQuestionBeenAnsweredByTheCurrentUser(question.Id, userId);

                if (questionHasBeenAnsweredByTheCurrentUser)
                {
                    bool wasTheQuestionAnsweredCorrectly = await this.questionService.WasTheQuestionAnsweredCorrectly(question.Id, userId);
                    if (!wasTheQuestionAnsweredCorrectly && isCorrect)
                    {
                        await this.questionService.UpdateAnsweredCorrectlyColumn(question.Id, userId);
                    }
                }
                else
                {
                    //UserAnsweredQuestion userAnsweredQuestion = new UserAnsweredQuestion
                    //{
                    //    UserId = Guid.Parse(userId),
                    //    QuestionId = question.Id,
                    //    AnsweredCorrectly = isCorrect
                    //};

                    //await this.dbContext.UsersAnsweredQuestions.AddAsync(userAnsweredQuestion);
                    //await this.dbContext.SaveChangesAsync();
                }
            }

            int totalQuestions = answerResults.Count;
            int correctAnswers = answerResults.Count(kv => kv.Value);
            int score = (int)Math.Round((double)correctAnswers / totalQuestions * 100);
            return score;
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

        public Task<bool> HasTheQuestionBeenAnsweredByTheCurrentUser(Guid questionId, string userId)
        {
            return this.dbContext
                .UsersAnsweredQuestions
                .AnyAsync(q => q.UserId.ToString() == userId && q.QuestionId == questionId);
        }
    }
}
