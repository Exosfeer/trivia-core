using trivia_api.Models.Converters;
using trivia_dal.DataTransferObjects;
using trivia_dal.Interfaces;
using System.Collections.Generic;

namespace trivia_api.Models.Containers
{
    public class CategoryContainer
    {
        private readonly ICategoryContext context;

        public CategoryContainer(ICategoryContext givenContext)
        {
            this.context = givenContext;
        }

        public Category GetById(string id)
        {
            CategoryDTOConverter dtoConverter = new CategoryDTOConverter();
            Category returnModel = new Category();
            returnModel.Id = id;

            if (context.GetById(id) != null)
            {
                CategoryDTO dto = context.GetById(id);

                returnModel = dtoConverter.DtoToModel(dto);
            }

            return returnModel;
        }

        public List<Category> SearhByName(string title)
        {
            CategoryDTOConverter dtoConverter = new CategoryDTOConverter();
            List<Category> returnList = new List<Category>();

            foreach (CategoryDTO dto in context.SearhByName(title))
            {
                returnList.Add(dtoConverter.DtoToModel(dto));
            }

            return returnList;
        }

        public List<Category> GetAll()
        {
            CategoryDTOConverter dtoConverter = new CategoryDTOConverter();
            List<Category> returnList = new List<Category>();

            foreach (CategoryDTO dto in context.GetAll())
            {
                returnList.Add(dtoConverter.DtoToModel(dto));
            }

            return returnList;
        }

        public List<Category> getAllQuestions(string id)
        {
            CategoryDTOConverter dtoConverter = new CategoryDTOConverter();
            List<Category> returnList = new List<Category>();

            foreach (CategoryDTO dto in context.getAllQuestions(id))
            {
                returnList.Add(dtoConverter.DtoToModel(dto));
            }

            return returnList;
        }

        public List<Category> getAllQuestionsAnswers(string id)
        {
            CategoryDTOConverter dtoConverter = new CategoryDTOConverter();
            List<Category> returnList = new List<Category>();

            foreach (CategoryDTO dto in context.getAllQuestionsAnswers(id))
            {
                returnList.Add(dtoConverter.DtoToModel(dto));
            }
            return returnList;
        }
    }
}
