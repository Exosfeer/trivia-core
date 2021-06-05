using trivia_api.Models;
using trivia_api.Models.Containers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using trivia_view.Models;
using trivia_view.Models.Converters;
using trivia_view.Models.DetailViewModels;
using System;
using System.Collections.Generic;

namespace trivia_view.Controllers
{
    public class CategoryControllerOld : Controller
    {
       /* private readonly CategoryContainer container;
        private readonly QuestionContainer questionContainer;

        public CategoryControllerOld(CategoryContainer givenContainer, QuestionContainer givenQuestionContainer)
        {
            container = givenContainer;
            questionContainer = givenQuestionContainer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CategoryModelConverter modelConverter = new CategoryModelConverter();
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                List<Category> categorys = new List<Category>();
                CategoryViewModel categoryVM = new CategoryViewModel();

                string findTerms = Request.Query["findTerms"];
                if (findTerms == null)
                {
                    categorys = container.GetAll();
                    categorys = this.ViewPageCategorys(categorys, Request.Query["pageNumber"]);
                }
                else
                {
                    categorys = container.SearhByName(findTerms);
                }
                categoryVM.ViewModels = modelConverter.ModelsToViewModels(categorys);

                return View(categoryVM);

            }
            return RedirectToAction("SignIn", "Account");

        }
        public IActionResult QuestionTitles(CategoryDetailViewModel categoryDVM)
        {

            if (HttpContext.Session.GetInt32("Account") != null)
            {
                return View(categoryDVM);
            }
            return RedirectToAction("SignIn", "Account");
        }
        public IActionResult QuestionAnswers(CategoryDetailViewModel categoryDVM)
        {

            if (HttpContext.Session.GetInt32("Account") != null)
            {
                return View(categoryDVM);
            }
            return RedirectToAction("SignIn", "Account");
        }
        public IActionResult Details(CategoryDetailViewModel categoryDVM)
        {

            if (HttpContext.Session.GetInt32("Account") != null)
            {
                AccountDetailViewModel account = JsonConvert.DeserializeObject<AccountDetailViewModel>(HttpContext.Session.GetString("Account"));
                QuestionViewModel questionVM = new QuestionViewModel(categoryDVM.Id, account.Id);
                QuestionModelConverter questionModelConverter = new QuestionModelConverter();
                List<Question> fetchedQuestions = questionContainer.GetAllByCategoryId(categoryDVM.Id);
                questionVM.categoryDetailViewModel = categoryDVM;
                questionVM.questionsViewModels = questionModelConverter.ModelsToViewModels(fetchedQuestions);

                return View(questionVM);
            }
            return RedirectToAction("SignIn", "Account");
        }
        public IActionResult UpdateCategory(CategoryViewModel categoryVM)
        {

            if (HttpContext.Session.GetInt32("Account") != null)
            {
                return View(categoryVM);
            }
            return RedirectToAction("SignIn", "Account");
        }
        public IActionResult CategoryQuestions()
        {

            CategoryModelConverter modelConverter = new CategoryModelConverter();
            if (HttpContext.Session.GetInt32("Account") != null)
            {

                List<Category> categorys = new List<Category>();
                CategoryViewModel categoryVM = new CategoryViewModel();
                string currentCategoryId = Request.Query["currentCategoryId"];
                if (currentCategoryId == null)
                {
                    currentCategoryId = "1";
                }
                int category_id = Int16.Parse(currentCategoryId);
                categorys = container.getAllQuestions(category_id);
                categoryVM.ViewModels = modelConverter.ModelsToViewModels(categorys);

                return View(categoryVM);
            }
            return RedirectToAction("SignIn", "Account");
        }
        public IActionResult CategoryQuestionsAnswers()
        {

            CategoryModelConverter modelConverter = new CategoryModelConverter();
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                List<Category> categorys = new List<Category>();
                CategoryViewModel categoryVM = new CategoryViewModel();
                string currentCategoryId = Request.Query["currentCategoryId"];
                if (currentCategoryId == null)
                {
                    currentCategoryId = "1";
                }
                int category_id = Int16.Parse(currentCategoryId);
                categorys = container.getAllQuestionsAnswers(category_id);
                categoryVM.ViewModels = modelConverter.ModelsToViewModels(categorys);

                return View(categoryVM);
            }
            return RedirectToAction("SignIn", "Account");
        }
        public IActionResult SearchResults()
        {

            CategoryModelConverter modelConverter = new CategoryModelConverter();
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                string zoekTermen = Request.Query["searchTerms"];
                List<Category> categorys = new List<Category>();
                CategoryViewModel categoryVM = new CategoryViewModel();

                categorys = container.SearhByName(zoekTermen);
                categoryVM.ViewModels = modelConverter.ModelsToViewModels(categorys);

                return View(categoryVM);
            }
            return RedirectToAction("SignIn", "Account");
        }

        private List<Category> ViewPageCategorys(List<Category> categorys, string currentPage = null, int perPageCategorysSize = 9)
        {
            int pageNumber = (String.IsNullOrEmpty(currentPage) || (int.Parse(currentPage) < 2)) ? 1 : int.Parse(currentPage); //check hier of de pagina is "geset", zo niet zet de paginanummer naar 1..
            int maxSize = categorys.Count - 1;
            int beginRange = (pageNumber * perPageCategorysSize) - (perPageCategorysSize - 0);
            int categorysPageSize = ((beginRange + perPageCategorysSize) > maxSize)
                ? (beginRange > maxSize)
                    ? -1
                    : (maxSize - beginRange)
                : perPageCategorysSize;

            if (categorysPageSize < 0)
            {
                return this.ViewPageCategorys(categorys, (pageNumber - 1).ToString());
            }
            else
            {
                ViewData["prevPage"] = (pageNumber - 1).ToString();
                ViewData["pageNumber"] = pageNumber.ToString();
                ViewData["nextPage"] = (pageNumber + 1).ToString();
                return categorys.GetRange(beginRange, categorysPageSize);
            }
        }*/
    }
}
