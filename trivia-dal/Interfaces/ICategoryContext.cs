using trivia_dal.DataTransferObjects;
using System.Collections.Generic;

namespace trivia_dal.Interfaces
{
    public interface ICategoryContext
    {
        CategoryDTO GetById(int id);
        List<CategoryDTO> SearhByName(string serchTerm);
        List<CategoryDTO> GetAll();
        List<CategoryDTO> getAllQuestions(int id);
        List<CategoryDTO> getAllQuestionsAnswers(int id);
    }
}
