using trivia_dal.Contexts.BaseSQL;
using trivia_dal.DataTransferObjects;
using trivia_dal.DataTransferObjects.DatasetParsers;
using trivia_dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;


namespace trivia_dal.Contexts
{
    public class AccountMssqlContext : MssqlBaseSQLContext, IAccountContext
    {
        public bool Delete(AccountDTO current)
        {
            try
            {
                string sql = "DELETE Account Where Id = @id";

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
        public int Insert(AccountDTO current)
        {
            try
            {
                string sql = "INSERT INTO Account(email, password, username) OUTPUT INSERTED.id VALUES(@email, HASHBYTES('SHA1', @password), @username)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", current.Email),
                    new KeyValuePair<string, string>("password", current.Password),
                    new KeyValuePair<string, string>("username", current.Username),
                };
                int result = ExecuteInsert(sql, parameters);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<AccountDTO> GetAll()
        {
            List<AccountDTO> dtoList = new List<AccountDTO>();
            string query = "SELECT * FROM Account";

            try
            {
                DataSet sqlResults = ExecuteQuery(query);

                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    AccountDTO dtoSqlResults = AccountDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                    dtoList.Add(dtoSqlResults);
                }

                return dtoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public AccountDTO GetById(int accountId)
        {
            AccountDTO dtoReturn = new AccountDTO(0);
            string sql = "SELECT * FROM Reactie WHERE Id = @id";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("id", accountId.ToString() ),
                };

            try
            {
                DataSet sqlResults = ExecuteSql(sql, parameters);

                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    dtoReturn = AccountDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dtoReturn;
        }
        public AccountDTO GetByName(AccountDTO account)
        {
            AccountDTO dtoReturn = new AccountDTO(0);
            string sql = "SELECT * FROM Account WHERE Email = @email AND Password =  HASHBYTES('SHA1', @password)";

            try
            {
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Email", account.Email ),
                    new KeyValuePair<string, string>("Password", account.Password),
                };

                DataSet sqlResults = ExecuteSql(sql, parameters);


                for (int i = 0; i < sqlResults.Tables[0].Rows.Count; i++)
                {
                    dtoReturn = AccountDatasetParser.DatasetToDataTransferObject(sqlResults, i);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dtoReturn;


        }
        public bool Update(AccountDTO current)
        {
            try
            {
                string sql = "UPDATE Account Set Email = @email,  Username = @username  Where Id = @id";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", current.Id.ToString()),
                    new KeyValuePair<string, string>("email", current.Email),
                    new KeyValuePair<string, string>("username", current.Username),
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
