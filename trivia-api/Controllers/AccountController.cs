using trivia_api.Models;
using trivia_api.Models.Containers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using trivia_view.Models.Converters;
using trivia_view.Models.DetailViewModels;


namespace trivia_view.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountContainer accountContainer;

        public AccountController(AccountContainer accountContainer)
        {
            this.accountContainer = accountContainer;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Registreer()
        {
            AccountDetailViewModel accountDetailViewModel = new AccountDetailViewModel();
            return View(accountDetailViewModel);
        }


        public IActionResult SignIn()
        {
            AccountDetailViewModel accountDetailViewModel = new AccountDetailViewModel();
            return View(accountDetailViewModel);
        }
        public IActionResult Update()
        {
            if (HttpContext.Session.GetInt32("Account") != null)
            {
                AccountDetailViewModel account = JsonConvert.DeserializeObject<AccountDetailViewModel>(HttpContext.Session.GetString("Account"));

                return View(account);

            }
            return RedirectToAction("SignIn", "Account");
        }


        public IActionResult Register(AccountDetailViewModel gegevenAccountDetailViewModel)
        {

            AccountModelConverter accountModelConverter = new AccountModelConverter();
            if (ModelState.IsValid)
            {
                Account gegevenAccountModel = accountModelConverter.ViewModelToModel(gegevenAccountDetailViewModel);
                Account ingelogdAccountModel = new Account(accountContainer.Insert(gegevenAccountModel));
                AccountDetailViewModel ingelogdAccountViewModel = accountModelConverter.ModelToViewModel(ingelogdAccountModel);
            }
            //return View(gegevenAccountDetailViewModel);
            return RedirectToAction("SignIn", "Account");

        }


        [HttpPost]
        public IActionResult Updated(AccountDetailViewModel gegevenAccountDetailViewModel)
        {
            AccountModelConverter accountModelConverter = new AccountModelConverter();
            if (ModelState.IsValid)
            {
                Account gegevenAccountModel = accountModelConverter.ViewModelToModel(gegevenAccountDetailViewModel);
                accountContainer.Update(gegevenAccountModel);
                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(gegevenAccountDetailViewModel));
                return RedirectToAction("Index", "Category");
            }
            return View(gegevenAccountDetailViewModel);
        }

        [HttpPost]
        public IActionResult Deleting(AccountDetailViewModel gegevenAccountDetailViewModel)
        {
            AccountModelConverter accountModelConverter = new AccountModelConverter();
            if (ModelState.IsValid)
            {
                Account gegevenAccountModel = accountModelConverter.ViewModelToModel(gegevenAccountDetailViewModel);
                accountContainer.Delete(gegevenAccountModel);
                HttpContext.Session.Clear(); //na verwijderen session stoppen.
                //return RedirectToAction("Index", "Category");
            }
            //return View(gegevenAccountDetailViewModel);
            return RedirectToAction("Index", "Category");

        }

        [HttpPost]
        public IActionResult SignInd(AccountDetailViewModel gegevenAccountDetailViewModel)
        {
            AccountModelConverter accountModelConverter = new AccountModelConverter();
            if (ModelState.IsValid)
            {
                Account gegevenAccountModel = accountModelConverter.ViewModelToModel(gegevenAccountDetailViewModel);
                Account fetchedAccountModel = accountContainer.GetByName(gegevenAccountModel);
                AccountDetailViewModel containerAccountViewModel = accountModelConverter.ModelToViewModel(fetchedAccountModel);

                gegevenAccountDetailViewModel = containerAccountViewModel;

                if (gegevenAccountDetailViewModel.Id != 0)
                {
                    HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(gegevenAccountDetailViewModel));

                    // return RedirectToAction("Index", "Category");
                }
            }
            //return View(gegevenAccountDetailViewModel);

            return RedirectToAction("Index", "Category");
        }

        public IActionResult Uitloggen()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Category");
        }
    }
}
