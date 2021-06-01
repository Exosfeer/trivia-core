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
                QuestionId = model.QuestionId,
                CategoryId = model.CategoryId,
                Difficulty = model.Difficulty,
                Type = model.Type,
                Title = model.Title,
                QuestionAnswers = model.QuestionAnswers,
                Published = model.Published,
                Updated = model.Updated,

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

                    QuestionId = model.QuestionId,
                    CategoryId = model.CategoryId,
                    Difficulty = model.Difficulty,
                    Type = model.Type,
                    Title = model.Title,
                    QuestionAnswers = model.QuestionAnswers,
                    Published = model.Published,
                    Updated = model.Updated,

                };
                viewModels.Add(viewModel);
            };
            return viewModels;
        }
        public Question ViewModelToModel(QuestionDetailViewModel viewModel)
        {
            Question model = new Question(viewModel.Id)
            {

                QuestionId = viewModel.QuestionId,
                CategoryId = viewModel.CategoryId,
                Difficulty = viewModel.Difficulty,
                Type = viewModel.Type,
                Title = viewModel.Title,
                QuestionAnswers = viewModel.QuestionAnswers,
                Published = viewModel.Published,
                Updated = viewModel.Updated,

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

                    QuestionId = viewModel.QuestionId,
                    CategoryId = viewModel.CategoryId,
                    Difficulty = viewModel.Difficulty,
                    Type = viewModel.Type,
                    Title = viewModel.Title,
                    QuestionAnswers = viewModel.QuestionAnswers,
                    Published = viewModel.Published,
                    Updated = viewModel.Updated,

                };
                models.Add(model);
            };
            return models;
        }
    }
}
