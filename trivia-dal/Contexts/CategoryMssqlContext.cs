using trivia_dal.Contexts.BaseSQL;
using trivia_dal.DataTransferObjects;
using trivia_dal.DataTransferObjects.DatasetParsers;
using trivia_dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
namespace trivia_dal.Contexts
{
    public class CategoryMssqlContext : MssqlBaseSQLContext, ICategoryContext
    {
        public List<CategoryDTO> getAllQuestions(int categoryId)
        {
            List<CategoryDTO> dtoList = new List<CategoryDTO>();
            string query = "SELECT * FROM Questions WHERE category_id='@categoryId' AND type = 'TREEVIA_QUESTION';";

            try
            {
                DataSet sqlResults = ExecuteQuery(query);

                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    CategoryDTO dtoSqlResults = CategoryDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                    dtoList.Add(dtoSqlResults);
                }

                return dtoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<CategoryDTO> getAllQuestionsAnswers(int categoryId)
        {
            List<CategoryDTO> dtoList = new List<CategoryDTO>();
            string query = "SELECT * FROM  Questions WHERE category_id='@categoryId' AND type = 'TREEVIA_ANSWER';";

            try
            {
                DataSet sqlResults = ExecuteQuery(query);

                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    CategoryDTO dtoSqlResults = CategoryDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                    dtoList.Add(dtoSqlResults);
                }

                return dtoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CategoryDTO> GetAll()
        {
            List<CategoryDTO> dtoList = new List<CategoryDTO>();
            string query = "SELECT * FROM Category;";

            try
            {
                DataSet sqlResults = ExecuteQuery(query);

                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    CategoryDTO dtoSqlResults = CategoryDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                    dtoList.Add(dtoSqlResults);
                }

                return dtoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public CategoryDTO GetById(int id)
        {
            CategoryDTO fetchSqlResult = new CategoryDTO(0); //return 0 dto
            string query = "SELECT * FROM Category WHERE id = '" + id.ToString() + "';";

            try
            {
                DataSet sqlResults = ExecuteQuery(query);


                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    fetchSqlResult = CategoryDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                }

                return fetchSqlResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CategoryDTO> SearhByName(string serchTerm)
        {
            List<CategoryDTO> dtoList = new List<CategoryDTO>();
            string query = "SELECT * FROM Category WHERE name LIKE '%" + serchTerm + "%';";

            try
            {
                DataSet sqlResults = ExecuteQuery(query);

                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    CategoryDTO dtoSqlResults = CategoryDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                    dtoList.Add(dtoSqlResults);
                }

                return dtoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
