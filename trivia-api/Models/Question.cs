using System;

namespace trivia_api.Models
{
    public class Question
    {
        private int id;
        private int categoryId;
        private int difficulty;
        private string title;
        private string image;
        private DateTime createdAt;
        private DateTime updatedAt;

        public int Id
        {
            private set => id = value;
            get => id;
        }

        public int CategoryId
        {
            private set => categoryId = value;
            get => categoryId;
        }

        public int Difficulty
        {
            set => difficulty = value;
            get => difficulty;
        }
        public string Title
        {
            set => title = value;
            get => title;
        }
        public string Image
        {
            set => image = value;
            get => image;
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

        public Question(int givenId)
        {
            Id = givenId;
        }
    }
}
