using System;
using System.Collections.Generic;
using System.Text;
using trivia_api.Models;

namespace test_trivia_api.Stubs
{
    class AccountModelStub
    {
        Account account1 = new Account();
        Account account2 = new Account();
        private List<Account> listAccounts = new List<Account>();

        public AccountModelStub()
        {
            //set values for test account one
            account1.Id = "test-account-one";
            account1.Email = "test1@mail.com";
            account1.Password = "password1";
            account1.Username = "username1";
            //set values for test account one
            account2.Id = "test-account-two";
            account2.Email = "test2@mail.com";
            account2.Password = "password2";
            account2.Username = "username2";

            //add test acounts to list of accounts.
            listAccounts.Add(account1);
            listAccounts.Add(account2);

        }


        public bool Delete(Account account)
        {
            if (account == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return true;
        }

        public List<Account> GetAll()
        {
            if (listAccounts == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return listAccounts;
        }
        public Account GetById(string id)
        {
            if (listAccounts == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            Account returnAccount = new Account();
            foreach (Account account in listAccounts)
            {
                if (account.Id == id)
                {
                    returnAccount = account;
                }
            }
            return returnAccount;
        }

        public Account GetByName(Account account)
        {
            if (listAccounts == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            Account returnAccount = new Account();
            foreach (Account iterateAccount in listAccounts)
            {
                if (iterateAccount.Username == account.Username)
                {
                    returnAccount = account;
                }
            }

            return returnAccount;
        }

        public int Insert(Account account)
        {
            if (account == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return 1337;
        }

        public bool Update(Account account)
        {
            if (account == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return true;
        }
    }
}
