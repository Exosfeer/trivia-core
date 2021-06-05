using trivia_dal.Contexts.BaseSQL;
using trivia_dal.DataTransferObjects;
using trivia_dal.DataTransferObjects.DatasetParsers;
using trivia_dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace trivia_dal.Contexts
{
    public class QuestionMssqlContext : MssqlBaseSQLContext, IQuestionContext
    {
        public bool Delete(QuestionDTO current)
        {
            try
            {
                string sql = "DELETE Question Where Id = @id";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", current.Id.ToString()),
                };
                return ExecuteDelete(sql, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Insert(QuestionDTO current)
        {
            try
            {
                string sql = "INSERT INTO Question(inhoud, type) OUTPUT INSERTED.id VALUES(@inhoud, @type)";//create reaction sql entry
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("questionId", current.QuestionId.ToString()),
                    new KeyValuePair<string, string>("categoryId", current.CategoryId.ToString()),
                    new KeyValuePair<string, string>("difficulty", current.Difficulty.ToString()),
                    new KeyValuePair<string, string>("type", current.Type),
                    new KeyValuePair<string, string>("title", current.Type),
                    new KeyValuePair<string, string>("questionAnswers", current.QuestionAnswers),
                };//create reactionItem parameters entry
                int questionId = ExecuteInsert(sql, parameters);//add question entry

                return questionId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<QuestionDTO> GetAll()
        {
            DataSet sqlResults = new DataSet();
            List<QuestionDTO> dtoList = new List<QuestionDTO>();
            string query = "SELECT * FROM Question";

            try
            {
                sqlResults = ExecuteQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }

            for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
            {
                QuestionDTO dtoSqlResults = QuestionDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                dtoList.Add(dtoSqlResults);
            }

            return dtoList;
        }
        public QuestionDTO GetById(string questionId)
        {
            QuestionDTO dtoReturn = new QuestionDTO("");
            DataSet sqlResults = new DataSet();
            string sql = "SELECT * FROM Question WHERE Id = @id";

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("id", questionId.ToString() ),
                };

            try
            {
                sqlResults = ExecuteSql(sql, parameters);

                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    dtoReturn = QuestionDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dtoReturn;
        }
        public List<QuestionDTO> GetAllByCategoryId(string categoryId)
        {
            List<QuestionDTO> returnList = new List<QuestionDTO>();
            DataSet sqlResults = new DataSet();
            string sql = "SELECT * From Question WHERE categoryId = @categoryId";

            try
            {
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("categoryId", categoryId.ToString() ),
                };

                sqlResults = ExecuteSql(sql, parameters);


                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    QuestionDTO dtoReturn = QuestionDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                    returnList.Add(dtoReturn);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return returnList;
        }
        
        public bool Update(QuestionDTO current)
        {
            try
            {
                string sql = "UPDATE Question Set Email = @email,  Username = @username  Where Id = @id";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", current.Id.ToString()),
                    new KeyValuePair<string, string>("questionId", current.QuestionId.ToString()),
                    new KeyValuePair<string, string>("categoryId", current.CategoryId.ToString()),
                    new KeyValuePair<string, string>("difficulty", current.Difficulty.ToString()),
                    new KeyValuePair<string, string>("type", current.Type.ToString()),            
                    new KeyValuePair<string, string>("title", current.Title.ToString()),
                    new KeyValuePair<string, string>("questionAnswers", current.Type.ToString()),
                };

                return ExecuteUpdate(sql, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
