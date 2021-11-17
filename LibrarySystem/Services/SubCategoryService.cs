using AutoMapper;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.SubCategory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SubCategoryViewModel>> GetSubCategoriesUsingStoredProcedure(int categoryId)
        {
            if (categoryId == 0)
            {
                return new List<SubCategoryViewModel>();
            }
            var subCategories = await _unitOfWork.SubCategories.GetSubCategoriesUsingStoredProcedureAsync(categoryId);
            return _mapper.Map<List<SubCategoryViewModel>>(subCategories);
        }

        public async Task<List<SubCategoryViewModel>> GetAllSubCategories()
        {
            var subCategories = await _unitOfWork.SubCategories.GetAllSubCategoriesAsync();
            return _mapper.Map<List<SubCategoryViewModel>>(subCategories);
        }

        public async Task<SubCategoryViewModel> GetSubCategoryById(int subCategoryId)
        {
            var subCategory = await _unitOfWork.SubCategories.GetSubCategoryByIdAsync(subCategoryId);
            return _mapper.Map<SubCategoryViewModel>(subCategory);
        }

        public async Task<bool> CreateNewSubCategory(SaveSubCategoryViewModel subCategoryViewModel)
        {
            try
            {
                var subCategory = _mapper.Map<SubCategory>(subCategoryViewModel);
                _unitOfWork.SubCategories.CreateSubCategory(subCategory);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error creating the subCategory: ", exp.Message);
                return false;
            }
        }

        public async Task<bool> UpdateSubCategory(int subCategoryId, SaveSubCategoryViewModel subCategoryViewModel)
        {
            try
            {
                var subCategory = _mapper.Map<SubCategory>(subCategoryViewModel);
                _unitOfWork.SubCategories.UpdateSubCategory(subCategory);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error updating the subCategory: ", exp.Message);
                return false;
            }
        }

        public async Task<bool> DeleteSubCategory(int subCategoryId)
        {
            try
            {
                var subCategory = await _unitOfWork.SubCategories.GetSubCategoryByIdAsync(subCategoryId);
                if (subCategory == null)
                {
                    throw new Exception("Error deleting the SubCategory: not found");
                }
                _unitOfWork.SubCategories.DeleteSubCategory(subCategory);
                await _unitOfWork.Complete();
                return true;
            }
            catch
            {
                throw new Exception("Error deleting the SubCategory: has books");
            }

        }

    }
}
