using System;
using System.Collections.Generic;
using System.Text;
using trivia_api.Models;

namespace test_trivia_api.Stubs
{
    class QuestionModelStub
    {
        Question question1 = new Question();
        Question question2 = new Question();
        private List<Question> listQuestions = new List<Question>();

        public QuestionModelStub()
        {
            //set values for test question one
            question1.Id = "test-question-one";
            question1.CategoryId = "category-id-one";
            question1.Difficulty = "easy";
            question1.Title = "title1";
            //set values for test question one
            question2.Id = "test-question-two";
            question2.CategoryId = "category-id-two";
            question2.Difficulty = "hard";
            question2.Title = "title2";

            //add test acounts to list of questions.
            listQuestions.Add(question1);
            listQuestions.Add(question2);

        }


        public bool Delete(Question question)
        {
            if (question == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return true;
        }

        public List<Question> GetAll()
        {
            if (listQuestions == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return listQuestions;
        }
        public Question GetById(string id)
        {
            if (listQuestions == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            Question returnQuestion = new Question();
            foreach (Question question in listQuestions)
            {
                if (question.Id == id)
                {
                    returnQuestion = question;
                }
            }
            return returnQuestion;
        }

        public Question GetByName(Question question)
        {
            if (listQuestions == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            Question returnQuestion = new Question();
            foreach (Question iterateQuestion in listQuestions)
            {
                if (iterateQuestion.Title == question.Title)
                {
                    returnQuestion = question;
                }
            }

            return returnQuestion;
        }

        public int Insert(Question question)
        {
            if (question == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return 1337;
        }

        public bool Update(Question question)
        {
            if (question == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return true;
        }
    }
}
