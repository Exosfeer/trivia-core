using trivia_dal.DataTransferObjects;


namespace trivia_api.Models.Converters
{
    public class QuestionDTOConverter
    {
        public Question DtoToModel(QuestionDTO dto)
        {
            Question model = new Question()
            {
                Id = dto.Id,
                SourceAPI = dto.SourceAPI,
                CategoryId = dto.CategoryId,
                Difficulty = dto.Difficulty,
                Type = dto.Type,
                Title = dto.Title,
                CorrectAnswer = dto.CorrectAnswer,
                IncorrectAnswers = dto.IncorrectAnswers,
                Published = dto.Published,
                Updated = dto.Updated,
            };

            return model;
        }

        public QuestionDTO ModelToDTO(Question model)
        {
            QuestionDTO dto = new QuestionDTO(model.Id)
            {
                SourceAPI = model.SourceAPI,
                CategoryId = model.CategoryId,
                Difficulty = model.Difficulty,
                Type = model.Type,
                Title = model.Title,
                CorrectAnswer = model.CorrectAnswer,
                IncorrectAnswers = model.IncorrectAnswers,
                Published = model.Published,
                Updated = model.Updated,
            };

            return dto;
        }

    }
}

