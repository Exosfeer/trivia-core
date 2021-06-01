using System;

namespace trivia_view.Models.DetailViewModels
{
    public class QuestionDetailViewModel
    {
        private int id;
        private int categoryId;
        private string type;
        private string inhoud;
        private int accountId;
        private DateTime published;
        private DateTime wijzigingsdatum;

        public int Id
        {
            set => id = value;
            get => id;
        }
        public int CategoryId
        {
            set => categoryId = value;
            get => categoryId;
        }
        public string Type
        {
            set => type = value;
            get => type;
        }
        public string Inhoud
        {
            set => inhoud = value;
            get => inhoud;
        }
        public int AccountId
        {
            set => accountId = value;
            get => accountId;
        }
        public DateTime Published
        {
            set => published = value;
            get => published;
        }
        public DateTime Wijzigingsdatum
        {
            set => wijzigingsdatum = value;
            get => wijzigingsdatum;
        }

        public QuestionDetailViewModel()
        {
        }
    }
}
