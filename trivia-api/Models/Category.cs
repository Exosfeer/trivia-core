﻿using System;

namespace trivia_api.Models
{
    public class Category
    {
        private int id;
        private string name;
        private string description;
        private string poster;
        private DateTime published;
        private DateTime updated;

        public int Id
        {
            private set => id = value;
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

        public Category(int givenId)
        {
            Id = givenId;
        }
    }
}
