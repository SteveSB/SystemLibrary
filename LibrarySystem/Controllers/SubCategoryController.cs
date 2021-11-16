using AutoMapper;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.SubCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LibrarySystem.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<SubCategoryController> _logger;

        public SubCategoryController(ISubCategoryService subCategoryService,
            ICategoryService categoryService,
            IMapper mapper,
            ILogger<SubCategoryController> logger)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var subCategories = await _subCategoryService.GetAllSubCategories();
            return View(subCategories);
        }

        public async Task<IActionResult> Create()
        {
            var subCategoryViewModel = new SaveSubCategoryViewModel();
            return await InitializeSubCategoryFormView(subCategoryViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subCategory = await _subCategoryService.GetSubCategoryById(id);

            if (subCategory == null)
                return NotFound();

            var subCategoryViewModel = _mapper.Map<SaveSubCategoryViewModel>(subCategory);

            return await InitializeSubCategoryFormView(subCategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([FromForm] SaveSubCategoryViewModel subCategoryViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return await InitializeSubCategoryFormView(subCategoryViewModel);
                }

                if (subCategoryViewModel.Id == 0)
                    await _subCategoryService.CreateNewSubCategory(subCategoryViewModel);
                else
                    await _subCategoryService.UpdateSubCategory(subCategoryViewModel.Id, subCategoryViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return await InitializeSubCategoryFormView(subCategoryViewModel);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _subCategoryService.DeleteSubCategory(id);
                if (!isDeleted)
                {
                    Response.StatusCode = 500;
                    return Json("Something went wrong");
                }
                return Json("Deleted");
            }
            catch (Exception exp)
            {
                Response.StatusCode = 500;
                return Json(exp.Message);
            }
        }

        private async Task<IActionResult> InitializeSubCategoryFormView(SaveSubCategoryViewModel subCategoryViewModel)
        {
            var categories = await _categoryService.GetCategoriesUsingStoredProcedure();
            subCategoryViewModel.Categories = new SelectList(categories, "Id", "Name");

            return View("SubCategoryForm", subCategoryViewModel);
        }

    }
}
