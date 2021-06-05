﻿using trivia_dal.DataTransferObjects;
using System.Collections.Generic;

namespace trivia_dal.Interfaces
{
    public interface ICategoryContext
    {
        CategoryDTO GetById(string id);
        List<CategoryDTO> SearhByName(string serchTerm);
        List<CategoryDTO> GetAll();
        List<CategoryDTO> getAllQuestions(string id);
        List<CategoryDTO> getAllQuestionsAnswers(string id);
    }
}
