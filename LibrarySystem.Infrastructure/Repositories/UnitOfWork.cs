using LibrarySystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IAuthorRepository Authors { get; }

        public IBookRepository Books { get; }

        public ICategoryRepository Categories { get; }

        public ISubCategoryRepository SubCategories { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository,
            ISubCategoryRepository subCategoryRepository)
        {
            _dbContext = applicationDbContext;
            Authors = authorRepository;
            Books = bookRepository;
            Categories = categoryRepository;
            SubCategories = subCategoryRepository;
        }

        public async Task Complete()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
