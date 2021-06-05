using System;
using System.Data;

namespace trivia_dal.DataTransferObjects.DatasetParsers
{
    public class CategoryDatasetParser
    {
        public static CategoryDTO DatasetToDataTransferObject(DataSet set, int rowIndex)
        {
            return new CategoryDTO(
                set.Tables[0].Rows[rowIndex][0].ToString() //Id
            )
            {
                Name = (string)set.Tables[0].Rows[rowIndex][1],
                Description = (string)set.Tables[0].Rows[rowIndex][2],
                Poster = (string)set.Tables[0].Rows[rowIndex][3],
                Published = (DateTime)set.Tables[0].Rows[rowIndex][4],
                Updated = (DateTime)set.Tables[0].Rows[rowIndex][5],
            };
        }
    }
}
