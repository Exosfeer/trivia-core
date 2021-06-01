using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace trivia_dal.Contexts.BaseSQL
{
    public class MssqlBaseSQLContext
    {
        /**
         * Fetch the connectiongstring named "DockerDatabase"
         */
        private String getConnectionString()
        {
            //return ("Server=mssql.fhict.local;Database=dbi458461;User Id=dbi458461;Password=M@?NSr_qHc$eFe9&");
            return ("SERVER=host.docker.internal; DATABASE=treevia_db; UID=sa; PASSWORD=databasePassword123;");
        }

        /**
         * Create a new SQL Connection string.
         */
        private SqlConnection getNewSqlConnection()
        {
            return new SqlConnection(this.getConnectionString());
        }

        /**
         * Execute a SQL Query string.
         */
        public DataSet ExecuteQuery(string sqlQuery)
        {
            DataSet sqlDataSet = new DataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            SqlConnection sqlConnection = getNewSqlConnection();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            try
            {
                //set-up SQL-query command
                sqlCommand.CommandText = sqlQuery;
                sqlAdapter.SelectCommand = sqlCommand;
                //execute SQL-query
                sqlConnection.Open();
                sqlAdapter.Fill(sqlDataSet);//fill dataset
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //extra exception message to inform the end-user.
                var errorMessage = "Connectie maken met de database is mislukt.. \n Zie de onderstaande error error: \n " + exception;
            }
            return sqlDataSet;
        }

        /**
         * Execute a SQL with parameters in a string.
         */
        public DataSet ExecuteSql(string sqlCommandText, List<KeyValuePair<string, string>> parameters)
        {
            DataSet sqlDataSet = new DataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter();
            using (SqlConnection connection = getNewSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlCommandText, connection);
                command.Parameters.AddRange(GetParameters(parameters));
                sqlAdapter.SelectCommand = command;

                try
                {
                    connection.Open();
                    sqlAdapter.Fill(sqlDataSet);
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return sqlDataSet;
        }

        /**
         * Execute a SQL Insert with parameters in a string.
         */
        public int ExecuteInsert(string sql, List<KeyValuePair<string, string>> parameters)
        {
            SqlConnection sqlConnection = getNewSqlConnection();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Parameters.AddRange(GetParameters(parameters));
            sqlCommand.CommandText = sql;
            try
            {
                sqlConnection.Open();
                int id = (int)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /**
         * Execute a SQL Update with parameters in a string.
         */
        public bool ExecuteUpdate(string sql, List<KeyValuePair<string, string>> parameters)
        {
            SqlConnection sqlConnection = getNewSqlConnection();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Parameters.AddRange(GetParameters(parameters));
            sqlCommand.CommandText = sql;
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                return true; //succesfull execution
            }
            catch (Exception)
            {
                throw;
            }
        }

        /**
         * Execute a SQL Delete with parameters in a string.
         */
        public bool ExecuteDelete(string sql, List<KeyValuePair<string, string>> parameters)
        {
            SqlConnection sqlConnection = getNewSqlConnection();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Parameters.AddRange(GetParameters(parameters));
            sqlCommand.CommandText = sql;
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                return true; //succesfull execution
            }
            catch (Exception)
            {
                throw;
            }

        }

        /**
         * Unpack the given parameters and return a array of SqlParameter.
         */
        private SqlParameter[] GetParameters(List<KeyValuePair<string, string>> parameters)
        {
            SqlParameter[] retVal = new SqlParameter[parameters.Count];
            foreach (KeyValuePair<string, string> kvp in parameters)
            {
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@" + kvp.Key,
                    Value = kvp.Value
                };
                retVal[parameters.IndexOf(kvp)] = param;
            }
            return retVal;
        }
    }
}
