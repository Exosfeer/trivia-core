using System;
using System.Data;

namespace trivia_dal.DataTransferObjects.DatasetParsers
{
    public class QuestionDatasetParser
    {
        public static QuestionDTO DatasetToDataTransferObject(DataSet set, int rowIndex)
        {
            return new QuestionDTO(
                (string)set.Tables[0].Rows[rowIndex][1] //Id
            )
            {
                SourceAPI = (string)set.Tables[0].Rows[rowIndex][2],
                CategoryId = (string)set.Tables[0].Rows[rowIndex][3],
                Difficulty = (string)set.Tables[0].Rows[rowIndex][4],
                Type = (string)set.Tables[0].Rows[rowIndex][5],
                Title = (string)set.Tables[0].Rows[rowIndex][6],
                CorrectAnswer = (string)set.Tables[0].Rows[rowIndex][7],
                IncorrectAnswers = (string)set.Tables[0].Rows[rowIndex][8],
                Published = (DateTime)set.Tables[0].Rows[rowIndex][9],
                Updated = (DateTime)set.Tables[0].Rows[rowIndex][10],
            };
        }
    }
}
