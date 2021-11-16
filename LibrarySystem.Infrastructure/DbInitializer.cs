using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DbInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedData()
        {
            await _dbContext.Database.EnsureCreatedAsync().ConfigureAwait(false);

            if (!_dbContext.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category()
                    {
                        Name = "Thriller",
                        Description = "This category is for thriller books"
                    },
                    new Category
                    {
                        Name = "Drama",
                        Description = "A category for drama books"
                    },
                    new Category
                    {
                        Name = "Science",
                        Description = "This category is a science books category"
                    },
                };

                _dbContext.Categories.AddRange(categories);

                var authors = new Author[]
                {
                    new Author() { Name = "William Shakespeare" },
                    new Author() { Name = "George R R Martin" },
                    new Author() { Name = "Agatha Christie" },
                    new Author() { Name = "Charles Darwin" },
                };

                _dbContext.Authors.AddRange(authors);

                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
