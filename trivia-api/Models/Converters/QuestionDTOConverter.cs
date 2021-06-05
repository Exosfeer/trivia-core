using trivia_dal.DataTransferObjects;


namespace trivia_api.Models.Converters
{
    public class QuestionDTOConverter
    {
        public Question DtoToModel(QuestionDTO dto)
        {
            Question model = new Question()
            {
                QuestionId = dto.QuestionId,
                CategoryId = dto.CategoryId,
                Difficulty = dto.Difficulty,
                Type = dto.Type,
                Title = dto.Title,
                QuestionAnswers = dto.QuestionAnswers,
                Published = dto.Published,
                Updated = dto.Updated,
            };

            return model;
        }

        public QuestionDTO ModelToDTO(Question model)
        {
            QuestionDTO dto = new QuestionDTO(model.Id)
            {
                QuestionId = model.QuestionId,
                CategoryId = model.CategoryId,
                Difficulty = model.Difficulty,
                Type = model.Type,
                Title = model.Title,
                QuestionAnswers = model.QuestionAnswers,
                Published = model.Published,
                Updated = model.Updated,
            };

            return dto;
        }

    }
}

