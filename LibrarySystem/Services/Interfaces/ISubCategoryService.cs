using LibrarySystem.ViewModels.SubCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task<List<SubCategoryViewModel>> GetSubCategoriesUsingStoredProcedure(int categoryId);

        Task<List<SubCategoryViewModel>> GetAllSubCategories();

        Task<SubCategoryViewModel> GetSubCategoryById(int subCategoryId);

        Task<bool> CreateNewSubCategory(SaveSubCategoryViewModel subCategoryViewModel);

        Task<bool> UpdateSubCategory(int subCategoryId, SaveSubCategoryViewModel subCategoryViewModel);

        Task<bool> DeleteSubCategory(int subCategoryId);

    }
}
