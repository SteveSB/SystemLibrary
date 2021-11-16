using Domain.Interfaces;
using LibrarySystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        Task<IEnumerable<SubCategory>> GetSubCategoriesUsingStoredProcedureAsync(int categoryId);
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync();
        Task<SubCategory> GetSubCategoryByIdAsync(int subCategoryId);
        void CreateSubCategory(SubCategory subCategory);
        void UpdateSubCategory(SubCategory subCategory);
        void DeleteSubCategory(SubCategory subCategory);
    }
}
