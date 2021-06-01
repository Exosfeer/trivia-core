using System;

namespace trivia_dal.DataTransferObjects
{
    public class CategoryDTO
    {
        private int id;
        private string name;
        private string description;
        private DateTime published;
        private DateTime updated;
        private string poster;

        public int Id
        {
            set => id = value;
            get => id;
        }
        public string Name
        {
            set => name = value;
            get => name;
        }
        public string Description
        {
            set => description = value;
            get => description;
        }
        public string Poster
        {
            set => poster = value;
            get => poster;
        }
        public DateTime Published
        {
            set => published = value;
            get => published;
        }
        public DateTime Updated
        {
            set => updated = value;
            get => updated;
        }

        public CategoryDTO(int id)
        {
            Id = id;
        }
    }
}
