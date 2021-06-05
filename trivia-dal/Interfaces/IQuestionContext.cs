using trivia_dal.DataTransferObjects;
using System.Collections.Generic;

namespace trivia_dal.Interfaces
{
    public interface IQuestionContext
    {
        bool Delete(QuestionDTO question);
        int Insert(QuestionDTO question);
        List<QuestionDTO> GetAll();
        QuestionDTO GetById(string id);
        List<QuestionDTO> GetAllByCategoryId(string categoryId);
        bool Update(QuestionDTO question);
    }
}
