using Domain.Interfaces;
using LibrarySystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesUsingStoredProcedureAsync();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
