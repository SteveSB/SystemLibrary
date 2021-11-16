using LibrarySystem.ViewModels.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategoriesUsingStoredProcedure();
        Task<List<CategoryViewModel>> GetAllCategories();

        Task<CategoryViewModel> GetCategoryById(int categoryId);

        Task<bool> CreateNewCategory(SaveCategoryViewModel categoryViewModel);

        Task<bool> UpdateCategory(int categoryId, SaveCategoryViewModel categoryViewModel);

        Task<bool> DeleteCategory(int categoryId);
    }
}
