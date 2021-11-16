using AutoMapper;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetCategoriesUsingStoredProcedure()
        {
            var categories = await _unitOfWork.Categories.GetCategoriesUsingStoredProcedureAsync();
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var categories = await _unitOfWork.Categories.GetAllCategoriesAsync();
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }

        public async Task<CategoryViewModel> GetCategoryById(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetCategoryByIdAsync(categoryId);
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<bool> CreateNewCategory(SaveCategoryViewModel categoryViewModel)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                _unitOfWork.Categories.CreateCategory(category);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error creating the category: ", exp.Message);
                return false;
            }
        }

        public async Task<bool> UpdateCategory(int categoryId, SaveCategoryViewModel categoryViewModel)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                _unitOfWork.Categories.UpdateCategory(category);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error updating the category: ", exp.Message);
                return false;
            }
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetCategoryByIdAsync(categoryId);
                if (category == null)
                {
                    throw new Exception("Error deleting the category: not found");
                }
                _unitOfWork.Categories.DeleteCategory(category);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                throw new Exception("Error deleting the category: has subcategories");
            }
        }
    }
}
