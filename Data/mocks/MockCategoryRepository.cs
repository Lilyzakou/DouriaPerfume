using System;
using DouriaPerfume.Data.Models;

namespace DouriaPerfume.Data.Interfaces.mocks
{
	public class MockCategoryRepository: ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                     {
                         new Category { CategoryName = "man", Description = "All men perfumes" },
                         new Category { CategoryName = "woman", Description = "All womenc perfumes" }
                     };
            }
        }
    }
}

