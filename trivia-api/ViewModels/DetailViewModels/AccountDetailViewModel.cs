using System;
using System.ComponentModel.DataAnnotations;

namespace trivia_view.Models.DetailViewModels
{
    public class AccountDetailViewModel
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
        [Required]
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
        public AccountDetailViewModel()
        {
        }
    }
}
