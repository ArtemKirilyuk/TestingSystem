﻿using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using PL.ViewModels;

namespace PL.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        #region user mapping
        public static UserViewModel ToMvcUser(this UserDTO userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                Age = userEntity.Age,
                Roles = userEntity.Roles,
                TestResults = userEntity.TestResults,
                Password = userEntity.Password,
                OldPassword = userEntity.OldPassword,
                NewPassword = userEntity.NewPassword,
                ConfirmPassword = userEntity.ConfirmPassword

            };
        }

        public static UserDTO ToBllUser(this UserViewModel userViewModel)
        {
            return new UserDTO()
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Email = userViewModel.Email,
                Age = userViewModel.Age,
                Roles = userViewModel.Roles,
                TestResults = userViewModel.TestResults,
                Password = userViewModel.Password,
                OldPassword = userViewModel.OldPassword,
                NewPassword = userViewModel.NewPassword,
                ConfirmPassword = userViewModel.ConfirmPassword
            };
        }
        #endregion
        #region test mapping
        public static TestViewModel ToMvcTest(this TestDTO testEntity)
        {
            return new TestViewModel()
            {
                Id = testEntity.Id,
                Name = testEntity.Name,
                BadAnswers = testEntity.BadAnswers,
                GoodAnswers = testEntity.GoodAnswers,
                Time = testEntity.Time,
                Description = testEntity.Description,
                IsValid = testEntity.IsValid,
                Creator = testEntity.Creator,
                Questions = testEntity.Questions.ToList(),
                Answers = testEntity.Answers.ToList()

            };
        }

        public static TestDTO ToBllTest(this TestViewModel testViewModel)
        {
            return new TestDTO()
            {
                Id = testViewModel.Id,
                Name = testViewModel.Name,
                BadAnswers = testViewModel.BadAnswers,
                GoodAnswers = testViewModel.GoodAnswers,
                Time = testViewModel.Time,
                Description = testViewModel.Description,
                IsValid = testViewModel.IsValid,
                Creator = testViewModel.Creator,
                Questions = testViewModel.Questions,
                Answers = testViewModel.Answers
            };
        }
        public static TestDTO ToBllTest(this CreateTestViewModel createTestViewModel)
        {
            return new TestDTO()
            {
                Name = createTestViewModel.Name,
                Time = createTestViewModel.Time,
                Creator = createTestViewModel.Creator,
                Description = createTestViewModel.Description,
                Questions = createTestViewModel.Questions.ToQuestionDtoCollection().ToList(),
                Answers = createTestViewModel.Answers.ToAnswerDtoCollection().ToList()
            };
        }
        public static Statistics ToMvcStatistics(this TestDTO testModel)
        {
            return new Statistics()
            {
                Name = testModel.Name,
                BadAnswers = testModel.BadAnswers,
                GoodAnswers = testModel.GoodAnswers,
                Creator = testModel.Creator,
                Answers = testModel.BadAnswers + testModel.GoodAnswers,
                Percentage = ((double)testModel.GoodAnswers/((double)testModel.GoodAnswers + (double)testModel.BadAnswers)*100).ToString("##.###")
            };
        }
        public static PassingViewModel ToMvcPassing(this TestDTO testModel)
        {
            return new PassingViewModel()
            {
                Id = testModel.Id,
                Name = testModel.Name,
                Time = testModel.Time,
                Questions = testModel.Questions.ToQuestionCollection().ToList(),
                Answers = testModel.Answers.ToAnswerCollection().ToList()
            };
        }
        public static TestDTO ToBllTest(this PassingViewModel passingModel)
        {
            return new TestDTO()
            {
                Id = passingModel.Id,
                Name = passingModel.Name,
                Time = passingModel.Time,
                Answers = passingModel.Answers.ToAnswerDtoCollection().ToList()
            };
        }
        #endregion
        #region testResult mapping
        public static TestResultViewModel ToMvcTestResult(this TestResultDTO testResultEntity)
        {
            return new TestResultViewModel()
            {
                Id = testResultEntity.Id,
                Name = testResultEntity.Name,
                GoodAnswers = testResultEntity.GoodAnswers,
                BadAnswers = testResultEntity.BadAnswers,
                DateComleted = testResultEntity.DateCompleted,
                User = testResultEntity.User

            };
        }

        public static TestResultDTO ToBllTestResult(this TestResultViewModel testResultViewModel)
        {
            return new TestResultDTO()
            {
                Id = testResultViewModel.Id,
                Name = testResultViewModel.Name,
                GoodAnswers = testResultViewModel.GoodAnswers,
                BadAnswers = testResultViewModel.BadAnswers,
                DateCompleted = testResultViewModel.DateComleted,
                User = testResultViewModel.User
            };
        }
        public static TestCompleteViewModel ToMvcTestComplete(this TestResultDTO testResult)
        {
            string Description = String.Empty;
            string result = String.Empty;
            double questions = testResult.BadAnswers + testResult.GoodAnswers;
            string points = (testResult.GoodAnswers/questions).ToString("####.#");
            switch (points)
            {
                case "":
                    Description = "It's very bad. Try your hand again, maybe you just got lucky. Or you were tested at random.";
                    result = "Test is not completed.";
                    break;
                case ",1":
                    Description = "It's very bad. Try your hand again, maybe you just got lucky. Or you were tested at random.";
                    result = "Test is not completed.";
                    break;
                case ",2":
                    Description = "Not bad, but it could have been worse.";
                    result = "Test is not completed.";
                    break;
                case ",3":
                    Description = "The important thing is not to win but to take part.";
                    result = "Test is not completed.";
                    break;
                case ",4":
                    Description = "The important thing is not to win but to take part.";
                    result = "Test is not completed.";
                    break;
                case ",5":
                    Description = "The important thing is not to win but to take part.";
                    result = "Test is not completed.";
                    break;
                case ",6":
                    Description = "You do not have quite a bit.";
                    result = "Test is not completed.";
                    break;
                case ",7":
                    Description = "Congratulations!";
                    result = "Test is completed.";
                    break;
                case ",8":
                    Description = "Congratulations!";
                    result = "Test is cmpleted.";
                    break;
                case ",9":
                    Description = "Congratulations! ";
                    result = "Test is completed.";
                    break;
                case "1":
                    Description = "Congratulations! You have very good data in this area. If you have the desire and time, you can build your test!";
                    result = "Test is completed.";
                    break;
                default:
                    Description = "Sorry, but while checking something went wrong test. Try to go through again.";
                    result = "Error.";
                    break;
            }
            return new TestCompleteViewModel()
            {
                GoodAnswers = testResult.GoodAnswers,
                Questions = testResult.BadAnswers + testResult.GoodAnswers,
                Description = Description,
                Result = result
            };
        }
        #endregion
        private static IEnumerable<QuestionDTO> ToQuestionDtoCollection(this ICollection<string> collectionQuestions)
        {
            foreach (var question in collectionQuestions)
            {
                yield return new QuestionDTO
                {
                    Value = question
                };
            }
        }

        private static IEnumerable<AnswerDTO> ToAnswerDtoCollection(this ICollection<string> collectionAnswers)
        {
            foreach (var answer in collectionAnswers)
            {
                yield return new AnswerDTO
                {
                    Value = answer
                };
            }
        }
        private static IEnumerable<string> ToQuestionCollection(this ICollection<QuestionDTO> collectionQuestionsDto)
        {
            foreach (var question in collectionQuestionsDto)
            {
                yield return question.Value;
            }
        }
        private static IEnumerable<string> ToAnswerCollection(this ICollection<AnswerDTO> collectionAnswersDto)
        {
            foreach (var answer in collectionAnswersDto)
            {
                yield return answer.Value;
            }
        }
    }
}