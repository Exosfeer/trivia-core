using System;

namespace trivia_api.Models
{
    public class QuestionAnswer
    {
        private int id;
        private int questionId;
        private int difficulty;
        private string text;
        private string source;
        private DateTime createdAt;
        private DateTime updatedAt;

        public int Id
        {
            private set => id = value;
            get => id;
        }

        public int QuestionId
        {
            private set => questionId = value;
            get => questionId;
        }

        public int Difficulty
        {
            set => difficulty = value;
            get => difficulty;
        }
        public string Text
        {
            set => text = value;
            get => text;
        }
        public string Source
        {
            set => source = value;
            get => source;
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

        public QuestionAnswer(int givenId)
        {
            Id = givenId;
        }
    }
}
