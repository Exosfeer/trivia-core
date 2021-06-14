using System;
using System.Collections.Generic;
using Xunit;
using test_trivia_api.Stubs;
using trivia_api.Models;

namespace test_trivia_api.Tests
{
    public class AccountsControllerTests
    {
        private static AccountModelStub modelStub = new AccountModelStub();

        [Theory]
        [InlineData("test-account-one")]
        public void GetById(string id)
        {
            Account results = modelStub.GetById(id);
            Assert.IsType<Account>(results);
        }
        [Theory]
        [InlineData("username1")]
        public void GetByName(string name)
        {
            Account testAccount = new Account();
            testAccount.Username = name;

            Account results = modelStub.GetByName(testAccount);

            Assert.IsType<Account>(results);
        }

        [Fact]
        public void Insert()
        {
            Account testAccount = new Account();
            testAccount.Id = "test-account-insert";

            Assert.IsType<int>(modelStub.Insert(testAccount));
        }

        [Fact]
        public void Update()
        {
            Account testAccount = new Account();
            testAccount.Id = "test-account-update";
            Assert.True(modelStub.Update(testAccount));
        }

        [Fact]
        public void Delete()
        {
            Account testAccount = new Account();
            testAccount.Id = "test-account-delete";
            Assert.True(modelStub.Delete(testAccount));
        }

        [Fact]
        public void GetAll()
        {
            List<Account> results = modelStub.GetAll();

            Assert.IsType<List<Account>>(results);
        }
    }
}
