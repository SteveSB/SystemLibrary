using LibrarySystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "William Shakespeare"
                },
                new Author
                {
                    Id = 2,
                    Name = "George R R Martin"
                },
                new Author
                {
                    Id = 3,
                    Name = "Agatha Christie"
                },
                new Author
                {
                    Id = 4,
                    Name = "Charles Darwin"
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Science",
                    Description = "This category is a science books category"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Thriller",
                    Description = "This category is for thriller books"
                },
                new Category
                {
                    Id = 3,
                    Name = "Drama",
                    Description = "A category for drama books"
                }
            );

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "General",
                    Description = "General scientific topics",
                },
                new SubCategory
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Physics",
                    Description = "For physics related topics"
                },
                new SubCategory
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Crime",
                    Description = "Crime related books"
                },
                new SubCategory
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Fantasy",
                    Description = "Books discussing fantasy"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "A Story of Ice and Fire",
                    Description = "GoT",
                    Price = 100,
                    AuthorId = 2,
                    SubCategoryId = 4
                },
                new Book
                {
                    Id = 2,
                    Title = "And Then There Were None",
                    Description = "The famous book",
                    Price = 75,
                    AuthorId = 3,
                    SubCategoryId = 3
                },
                new Book
                {
                    Id = 3,
                    Title = "On the Origin of Species",
                    Description = "The theories of evolution by natural selection",
                    Price = 10,
                    AuthorId = 4,
                    SubCategoryId = 1
                }
            );
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
