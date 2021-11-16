using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesUsingStoredProcedureAsync(int categoryId)
        {
            var param = new SqlParameter("@CategoryId", categoryId);

            return await _context.SubCategories.FromSqlRaw("GetAllSubCategories @CategoryId", param).ToListAsync();
        }

        public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync()
        {
            return await FindAll()
                        .OrderBy(subCategory => subCategory.Name)
                        .ToListAsync();
        }

        public async Task<SubCategory> GetSubCategoryByIdAsync(int subCategoryId)
        {
            return await FindByCondition(subCategory => subCategory.Id == subCategoryId)
                        .FirstOrDefaultAsync();
        }

        public void CreateSubCategory(SubCategory subCategory)
        {
            Create(subCategory);
        }

        public void UpdateSubCategory(SubCategory subCategory)
        {
            Update(subCategory);
        }

        public void DeleteSubCategory(SubCategory subCategory)
        {
            Delete(subCategory);
        }

    }
}
