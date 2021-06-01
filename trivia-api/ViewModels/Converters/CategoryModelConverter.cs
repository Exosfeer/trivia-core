using trivia_api.Models;
using trivia_view.Models.DetailViewModels;
using System.Collections.Generic;

namespace trivia_view.Models.Converters
{
    public class CategoryModelConverter
    {
        public List<CategoryDetailViewModel> ModelsToViewModels(List<Category> models)
        {
            List<CategoryDetailViewModel> viewModels = new List<CategoryDetailViewModel>();
            foreach (Category model in models)
            {
                CategoryDetailViewModel viewModel = new CategoryDetailViewModel()
                {
                    Id = model.Id,
                    Plot = model.Plot,
                    Type = model.Type,
                    Genre = model.Genre,
                    Titel = model.Titel,
                    AantalMinuten = model.AantalMinuten,
                    Kijkwijzer = model.Kijkwijzer,
                    Published = model.Published,
                    Poster = model.Poster,

                };
                viewModels.Add(viewModel);
            };
            return viewModels;
        }
        public List<Category> ViewModelsToModels(List<CategoryDetailViewModel> viewModels)
        {
            List<Category> models = new List<Category>();
            foreach (CategoryDetailViewModel viewModel in viewModels)
            {
                Category model = new Category(viewModel.Id)
                {
                    Plot = viewModel.Plot,
                    Type = viewModel.Type,
                    Genre = viewModel.Genre,
                    Titel = viewModel.Titel,
                    AantalMinuten = viewModel.AantalMinuten,
                    Kijkwijzer = viewModel.Kijkwijzer,
                    Published = viewModel.Published,
                    Poster = viewModel.Poster,

                };
                models.Add(model);
            };
            return models;
        }
    }
}
