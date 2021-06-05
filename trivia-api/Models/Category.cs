using System;

namespace trivia_api.Models
{
    public class Category
    {
        private string id;
        private string name;
        private DateTime createdAt;
        private DateTime updatedAt;

        public string Id
        {
            set => id = value;
            get => id;
        }
        public string Name
        {
            set => name = value;
            get => name;
        }
        public DateTime CreatedAt
        {
            set => createdAt = value;
            get => createdAt;
        }
        public DateTime UpdatedAt
        {
            set => updatedAt = value;
            get => updatedAt;
        }

        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
