using System;
using System.Collections.Generic;
using System.Text;
using trivia_api.Models;

namespace test_trivia_api.Stubs
{
    class CategoryModelStub
    {
        Category category1 = new Category();
        Category category2 = new Category();
        private List<Category> listCategories = new List<Category>();

        public CategoryModelStub()
        {
            //set values for test category one
            category1.Id = "test-category-one";
            category1.Poster = "https://categoryposterurl.com/category-one";
            category1.Description = "category-description-one";
            category1.Name = "category-name-one";
            //set values for test category one
            category2.Id = "test-category-two";
            category2.Poster = "https://categoryposterurl.com/category-two";
            category2.Description = "category-description-two";
            category2.Name = "category-name-two";

            //add test acounts to list of categorys.
            listCategories.Add(category1);
            listCategories.Add(category2);

        }


        public bool Delete(Category category)
        {
            if (category == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return true;
        }

        public List<Category> GetAll()
        {
            if (listCategories == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return listCategories;
        }
        public Category GetById(string id)
        {
            if (listCategories == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            Category returnCategory = new Category();
            foreach (Category category in listCategories)
            {
                if (category.Id == id)
                {
                    returnCategory = category;
                }
            }
            return returnCategory;
        }

        public Category GetByName(Category category)
        {
            if (listCategories == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            Category returnCategory = new Category();
            foreach (Category iterateCategory in listCategories)
            {
                if (iterateCategory.Name == category.Name)
                {
                    returnCategory = category;
                }
            }

            return returnCategory;
        }

        public int Insert(Category category)
        {
            if (category == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return 1337;
        }

        public bool Update(Category category)
        {
            if (category == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return true;
        }
    }
}
