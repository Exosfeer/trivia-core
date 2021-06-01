using trivia_dal.DataTransferObjects;
using System.Collections.Generic;

namespace trivia_dal.Interfaces
{
    public interface IQuestionContext
    {
        bool Delete(QuestionDTO question);
        int Insert(QuestionDTO question);
        List<QuestionDTO> GetAll();
        QuestionDTO GetById(int id);
        List<QuestionDTO> GetAllByCategoryId(int categoryId);
        bool Update(QuestionDTO question);
    }
}
