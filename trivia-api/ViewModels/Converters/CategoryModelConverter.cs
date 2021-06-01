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
                    Name = model.Name,
                    Description = model.Description,
                    Poster = model.Poster,
                    Published = model.Published,
                    Updated = model.Updated,

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
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Poster = viewModel.Poster,
                    Published = viewModel.Published,
                    Updated = viewModel.Updated,

                };
                models.Add(model);
            };
            return models;
        }
    }
}
