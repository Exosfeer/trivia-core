using System;
using System.Collections.Generic;
using Xunit;
using test_trivia_api.Stubs;
using trivia_api.Models;

namespace test_trivia_api.Tests
{
    public class QuestionsControllerTests
    {
        private static QuestionModelStub modelStub = new QuestionModelStub();

        [Theory]
        [InlineData("test-account-one")]
        public void GetById(string id)
        {
            Question results = modelStub.GetById(id);
            Assert.IsType<Question>(results);
        }
        [Theory]
        [InlineData("username1")]
        public void GetByName(string name)
        {
            Question testQuestion = new Question();
            testQuestion.Title = name;

            Question results = modelStub.GetByName(testQuestion);

            Assert.IsType<Question>(results);
        }

        [Fact]
        public void Insert()
        {
            Question testQuestion = new Question();
            testQuestion.Id = "test-account-insert";

            Assert.IsType<int>(modelStub.Insert(testQuestion));
        }

        [Fact]
        public void Update()
        {
            Question testQuestion = new Question();
            testQuestion.Id = "test-account-update";
            Assert.True(modelStub.Update(testQuestion));
        }

        [Fact]
        public void Delete()
        {
            Question testQuestion = new Question();
            testQuestion.Id = "test-account-delete";
            Assert.True(modelStub.Delete(testQuestion));
        }

        [Fact]
        public void GetAll()
        {
            List<Question> results = modelStub.GetAll();

            Assert.IsType<List<Question>>(results);
        }
    }
}
