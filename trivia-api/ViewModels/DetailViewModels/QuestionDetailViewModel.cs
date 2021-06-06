using System;

namespace trivia_view.Models.DetailViewModels
{
    public class QuestionDetailViewModel
    {
        private string id;
        private string sourceAPI;
        private string categoryId;
        private string difficulty;
        private string type;
        private string title;
        //private string questionAnswers;
        private string correctAnswer;
        private string incorrectAnswers;
        private DateTime published;
        private DateTime updated;

        public string Id
        {
            set => id = value;
            get => id;
        }
        public string SourceAPI
        {
            set => sourceAPI = value;
            get => sourceAPI;
        }

        public string CategoryId
        {
            set => categoryId = value;
            get => categoryId;
        }

        public string Difficulty
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
        /*        public string QuestionAnswers
                {
                    set => questionAnswers = value;
                    get => questionAnswers;
                }*/
        public string CorrectAnswer
        {
            set => correctAnswer = value;
            get => correctAnswer;
        }
        public string IncorrectAnswers
        {
            set => incorrectAnswers = value;
            get => incorrectAnswers;
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
