using trivia_api.Models;
using trivia_api.Models.Containers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trivia_view.Models.Converters;
using trivia_view.Models.DetailViewModels;
using System.Collections.Generic;

namespace trivia_view.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionContainer questionContainer;

        public QuestionController(QuestionContainer questionContainer)
        {
            this.questionContainer = questionContainer;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryBeoordeling()
        {
            return View();
        }
        public IActionResult CategoryBericht()
        {
            return View();
        }


        public IActionResult CategoryAccountQuestions(string categoryId, string accountId, string difficulty = "EASY")
        {
            if (ModelState.IsValid && (HttpContext.Session.GetString("Account") != null))
            {

                QuestionModelConverter questionModelConverter = new QuestionModelConverter();
                QuestionDetailViewModel newQuestionDetailViewModel = new QuestionDetailViewModel();
                newQuestionDetailViewModel.CategoryId = categoryId;
                newQuestionDetailViewModel.SourceAPI = accountId;
                newQuestionDetailViewModel.Difficulty = difficulty;
                newQuestionDetailViewModel.Type = "TREEVIA_QUESTION";
                Question nieuweQuestionModel = questionModelConverter.ViewModelToModel(newQuestionDetailViewModel);
                Question questionModel = new Question();
                questionModel.Id = questionContainer.Insert(nieuweQuestionModel).ToString();
                QuestionDetailViewModel questionDetailViewModel = questionModelConverter.ModelToViewModel(questionModel);
            }
            return RedirectToAction("Index", "Category");

        }


        public IActionResult CategoryAccountQuestionsAnswers(string categoryId, string sourceAPI, string categoryComment)
        {
            if (ModelState.IsValid && (HttpContext.Session.GetString("Account") != null))
            {
                QuestionModelConverter questionModelConverter = new QuestionModelConverter();
                QuestionDetailViewModel newQuestionDetailViewModel = new QuestionDetailViewModel();
                newQuestionDetailViewModel.CategoryId = categoryId;
                newQuestionDetailViewModel.SourceAPI = sourceAPI;
                newQuestionDetailViewModel.CorrectAnswer = categoryComment.ToString();
                newQuestionDetailViewModel.IncorrectAnswers = categoryComment.ToString();
                newQuestionDetailViewModel.Type = "TREEVIA_ANSWER";
                Question nieuweQuestionModel = questionModelConverter.ViewModelToModel(newQuestionDetailViewModel);
                Question questionModel = new Question();
                questionModel.Id = questionContainer.Insert(nieuweQuestionModel).ToString();
                QuestionDetailViewModel questionDetailViewModel = questionModelConverter.ModelToViewModel(questionModel);
            }
            return RedirectToAction("Index", "Category");

        }

        public List<QuestionDetailViewModel> GetCategoryQuestions(string categoryId)
        {
            List<QuestionDetailViewModel> returnList = new List<QuestionDetailViewModel>();

            QuestionModelConverter questionModelConverter = new QuestionModelConverter();
            List<Question> fetchedQuestions = questionContainer.GetAllByCategoryId(categoryId);
            returnList = questionModelConverter.ModelsToViewModels(fetchedQuestions);

            return returnList;

        }
    }
}
