using System;

namespace trivia_api.Models
{
    /**
     * Dit is de 'Account' class.
     * Deze account wordt benut als een accountaccount class.
     * Hiermee zal de eindaccount kunnen inloggen en data binden aan zijn accountaccount.
     * Aan dit Object voegen we de data van de MSSQL Table 'Account' toe
     * Een account class is latijd gebonden aan een Id.
     * */
    public class Account
    {
        private string id;
        private string email;
        private string password;
        private DateTime createdAt;
        private DateTime lastLogin;
        private string username;

        public string Id
        {
            set => id = value;
            get => id;
        }
        public string Email
        {
            set => email = value;
            get => email;
        }
        public string Username
        {
            set => username = value;
            get => username;
        }
        public string Password
        {
            set => password = value;
            get => password;
        }
        public DateTime LastLogin
        {
            set => lastLogin = value;
            get => lastLogin;
        }

        public DateTime CreatedAt
        {
            set => createdAt = value;
            get => createdAt;

        }
        public Account()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            LastLogin = DateTime.Now;
        }
    }
}
