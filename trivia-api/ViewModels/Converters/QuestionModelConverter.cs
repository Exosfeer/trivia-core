using trivia_api.Models;
using trivia_view.Models.DetailViewModels;
using System.Collections.Generic;

namespace trivia_view.Models.Converters
{
    public class QuestionModelConverter
    {
        public QuestionDetailViewModel ModelToViewModel(Question model)
        {
            QuestionDetailViewModel viewModel = new QuestionDetailViewModel()
            {
                Id = model.Id,
                CategoryId = model.CategoryId,
                Type = model.Type,
                Inhoud = model.Inhoud,
                AccountId = model.AccountId,
                Published = model.Published,
                Wijzigingsdatum = model.Wijzigingsdatum,

            };
            return viewModel;
        }
        public List<QuestionDetailViewModel> ModelsToViewModels(List<Question> models)
        {
            List<QuestionDetailViewModel> viewModels = new List<QuestionDetailViewModel>();
            foreach (Question model in models)
            {
                QuestionDetailViewModel viewModel = new QuestionDetailViewModel()
                {
                    Id = model.Id,
                    CategoryId = model.CategoryId,
                    Type = model.Type,
                    Inhoud = model.Inhoud,
                    AccountId = model.AccountId,
                    Published = model.Published,
                    Wijzigingsdatum = model.Wijzigingsdatum,

                };
                viewModels.Add(viewModel);
            };
            return viewModels;
        }
        public Question ViewModelToModel(QuestionDetailViewModel viewModel)
        {
            Question model = new Question(viewModel.Id)
            {
                CategoryId = viewModel.CategoryId,
                Type = viewModel.Type,
                Inhoud = viewModel.Inhoud,
                AccountId = viewModel.AccountId,
                Published = viewModel.Published,
                Wijzigingsdatum = viewModel.Wijzigingsdatum,

            };

            return model;
        }
        public List<Question> ViewModelsToModels(List<QuestionDetailViewModel> viewModels)
        {
            List<Question> models = new List<Question>();
            foreach (QuestionDetailViewModel viewModel in viewModels)
            {
                Question model = new Question(viewModel.Id)
                {
                    CategoryId = viewModel.CategoryId,
                    Type = viewModel.Type,
                    Inhoud = viewModel.Inhoud,
                    AccountId = viewModel.AccountId,
                    Published = viewModel.Published,
                    Wijzigingsdatum = viewModel.Wijzigingsdatum,

                };
                models.Add(model);
            };
            return models;
        }
    }
}
