using DouriaPerfume.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DouriaPerfume.Data.Models;
using DouriaPerfume.Data;
using DouriaPerfume.Data.Interfaces;

namespace DouriaPerfume.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> Categories => _appDbContext.Categories;

        object ICategoryRepository.Categories => throw new NotImplementedException();
    }
}