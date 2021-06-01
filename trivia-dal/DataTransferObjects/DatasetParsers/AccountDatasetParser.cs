using System;
using System.Data;

namespace trivia_dal.DataTransferObjects.DatasetParsers
{
    public class AccountDatasetParser
    {
        public static AccountDTO DatasetToDataTransferObject(DataSet set, int rowIndex)
        {
            return new AccountDTO(
                (int)set.Tables[0].Rows[rowIndex][0] //Id
            )
            {
                Email = (string)set.Tables[0].Rows[rowIndex][1],
                Username = (string)set.Tables[0].Rows[rowIndex][2],
                Password = (string)set.Tables[0].Rows[rowIndex][3],
                LastLogin = (DateTime)set.Tables[0].Rows[rowIndex][4],
                CreatedAt = (DateTime)set.Tables[0].Rows[rowIndex][5],
            };
        }
    }
}
