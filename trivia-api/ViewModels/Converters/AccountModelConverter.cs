using trivia_api.Models;
using trivia_view.Models.DetailViewModels;
using System.Collections.Generic;

namespace trivia_view.Models.Converters
{
    public class AccountModelConverter
    {
        public AccountDetailViewModel ModelToViewModel(Account model)
        {
            AccountDetailViewModel viewModel = new AccountDetailViewModel()
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                CreatedAt = model.CreatedAt,
                LastLogin = model.LastLogin,
                Username = model.Username,

            };

            return viewModel;
        }
        public List<AccountDetailViewModel> ModelsToViewModels(List<Account> models)
        {
            List<AccountDetailViewModel> viewModels = new List<AccountDetailViewModel>();
            foreach (Account model in models)
            {
                AccountDetailViewModel viewModel = new AccountDetailViewModel()
                {
                    Id = model.Id,
                    Email = model.Email,
                    Password = model.Password,
                    CreatedAt = model.CreatedAt,
                    LastLogin = model.LastLogin,
                    Username = model.Username,

                };
                viewModels.Add(viewModel);
            };
            return viewModels;
        }
        public Account ViewModelToModel(AccountDetailViewModel viewModel)
        {
            Account model = new Account()
            {
                Id = viewModel.Id,
                Email = viewModel.Email,
                Password = viewModel.Password,
                CreatedAt = viewModel.CreatedAt,
                LastLogin = viewModel.LastLogin,
                Username = viewModel.Username,

            };

            return model;
        }

        public List<Account> ViewModelsToModels(List<AccountDetailViewModel> viewModels)
        {
            List<Account> models = new List<Account>();
            foreach (AccountDetailViewModel viewModel in viewModels)
            {
                Account model = new Account()
                {
                    Id = viewModel.Id,
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    CreatedAt = viewModel.CreatedAt,
                    LastLogin = viewModel.LastLogin,
                    Username = viewModel.Username,

                };
                models.Add(model);
            };
            return models;
        }
    }
}
