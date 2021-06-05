using trivia_api.Models.Converters;
using trivia_dal.DataTransferObjects;
using trivia_dal.Interfaces;
using System.Collections.Generic;

namespace trivia_api.Models.Containers
{
    public class QuestionContainer
    {
        private readonly IQuestionContext context;
        public QuestionContainer(IQuestionContext givenContext)
        {
            this.context = givenContext;
        }

        public int Insert(Question current)
        {
            QuestionDTOConverter dtoConverter = new QuestionDTOConverter();
            QuestionDTO dto = dtoConverter.ModelToDTO(current);
            return context.Insert(dto);
        }

        public List<Question> GetAllByCategoryId(string categoryId)
        {
            QuestionDTOConverter dtoConverter = new QuestionDTOConverter();
            List<Question> returnList = new List<Question>();

            foreach (QuestionDTO dto in context.GetAllByCategoryId(categoryId))
            {
                returnList.Add(dtoConverter.DtoToModel(dto));
            }

            return returnList;
        }

        public Question GetById(string id)
        {
            QuestionDTOConverter dtoConverter = new QuestionDTOConverter();
            Question returnModel = new Question();
            returnModel.Id = id;

            if ( context.GetById(id) != null) //TODO: Double check this guard.
            {
                QuestionDTO dto = context.GetById(id);

                returnModel = dtoConverter.DtoToModel(dto);
            }

            return returnModel;
        }

        public List<Question> GetAll()
        {
            QuestionDTOConverter dtoConverter = new QuestionDTOConverter();
            List<Question> returnList = new List<Question>();

            foreach (QuestionDTO dto in context.GetAll())
            {
                returnList.Add(dtoConverter.DtoToModel(dto));
            }

            return returnList;
        }

    }

}
