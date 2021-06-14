using System;
using System.Collections.Generic;
using Xunit;
using test_trivia_api.Stubs;
using trivia_api.Models;

namespace test_trivia_api.Tests
{
    public class CategoriesControllerTests
    {
        private static CategoryModelStub modelStub = new CategoryModelStub();

        [Theory]
        [InlineData("test-account-one")]
        public void GetById(string id)
        {
            Category results = modelStub.GetById(id);
            Assert.IsType<Category>(results);
        }
        [Theory]
        [InlineData("username1")]
        public void GetByName(string name)
        {
            Category testCategory = new Category();
            testCategory.Name = name;

            Category results = modelStub.GetByName(testCategory);

            Assert.IsType<Category>(results);
        }

        [Fact]
        public void Insert()
        {
            Category testCategory = new Category();
            testCategory.Id = "test-account-insert";

            Assert.IsType<int>(modelStub.Insert(testCategory));
        }

        [Fact]
        public void Update()
        {
            Category testCategory = new Category();
            testCategory.Id = "test-account-update";
            Assert.True(modelStub.Update(testCategory));
        }

        [Fact]
        public void Delete()
        {
            Category testCategory = new Category();
            testCategory.Id = "test-account-delete";
            Assert.True(modelStub.Delete(testCategory));
        }

        [Fact]
        public void GetAll()
        {
            List<Category> results = modelStub.GetAll();

            Assert.IsType<List<Category>>(results);
        }
    }
}
