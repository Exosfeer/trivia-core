using System;
using System.Data;

namespace trivia_dal.DataTransferObjects.DatasetParsers
{
    public class QuestionDatasetParser
    {
        public static QuestionDTO DatasetToDataTransferObject(DataSet set, int rowIndex)
        {
            return new QuestionDTO(
                (int)set.Tables[0].Rows[rowIndex][1] //Id
            )
            {
                QuestionId = (int)set.Tables[0].Rows[rowIndex][2],
                CategoryId = (int)set.Tables[0].Rows[rowIndex][3],
                Difficulty = (int)set.Tables[0].Rows[rowIndex][4],
                Type = (string)set.Tables[0].Rows[rowIndex][5],
                Title = (string)set.Tables[0].Rows[rowIndex][6],
                QuestionAnswers = (string)set.Tables[0].Rows[rowIndex][7],
                Published = (DateTime)set.Tables[0].Rows[rowIndex][8],
                Updated = (DateTime)set.Tables[0].Rows[rowIndex][9],
            };
        }
    }
}
