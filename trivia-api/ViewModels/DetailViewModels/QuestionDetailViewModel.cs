using System;

namespace trivia_view.Models.DetailViewModels
{
    public class QuestionDetailViewModel
    {
        private string id;
        private int questionId;
        private int categoryId;
        private int difficulty;
        private string type;
        private string title;
        private string questionAnswers;
        private DateTime published;
        private DateTime updated;

        public string Id
        {
            set => id = value;
            get => id;
        }
        public int QuestionId
        {
            set => questionId = value;
            get => questionId;
        }

        public int CategoryId
        {
            set => categoryId = value;
            get => categoryId;
        }

        public int Difficulty
        {
            set => difficulty = value;
            get => difficulty;
        }
        public string Type
        {
            set => type = value;
            get => type;
        }
        public string Title
        {
            set => title = value;
            get => title;
        }
        public string QuestionAnswers
        {
            set => questionAnswers = value;
            get => questionAnswers;
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

        public QuestionDetailViewModel()
        {
        }
    }
}
