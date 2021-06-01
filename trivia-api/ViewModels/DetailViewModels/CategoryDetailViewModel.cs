using System;

namespace trivia_view.Models.DetailViewModels
{
    public class CategoryDetailViewModel
    {
        private int id;
        private string plot;
        private string type;
        private string genre;
        private string titel;
        private int aantalMinuten;
        private string kijkwijzer;
        private DateTime published;
        private string poster;


        public int Id
        {
            set => id = value;
            get => id;
        }
        public int AantalMinuten //minuten
        {
            set => aantalMinuten = value;
            get => aantalMinuten;
        }
        public string Plot
        {
            set => plot = value;
            get => plot;

        }
        public string Type
        {
            set => type = value;
            get => type;
        }
        public string Genre
        {
            set => genre = value;
            get => genre;
        }
        public string Titel
        {
            set => titel = value;
            get => titel;
        }
        public string Kijkwijzer
        {
            set => kijkwijzer = value;
            get => kijkwijzer;
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
        public CategoryDetailViewModel()
        {
        }
    }
}
