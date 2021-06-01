using System;

namespace trivia_dal.DataTransferObjects
{
    /**
     * 
     * Dit is mijn account DTO. 
     * Dit is een accountaccount class.
     * Hiermee zal de eindaccount kunnen inloggen en data binden aan zijn accountaccount.
     * Aan dit Object voegen we de data van de MSSQL Table 'Account' toe
     * */
    public class AccountDTO
    {
        private int id;
        private string email;
        private string password;
        private DateTime createdAt;
        private DateTime lastLogin;
        private string username;

        public int Id
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

        public AccountDTO(int id)
        {
            Id = id; //Wijs dit account object een Id toe.
        }

    }
}
