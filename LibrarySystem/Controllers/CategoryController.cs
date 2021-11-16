using AutoMapper;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LibrarySystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            IMapper mapper,
            ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var categorys = await _categoryService.GetAllCategories();
            return View(categorys);
        }

        public async Task<IActionResult> Create()
        {
            var categoryViewModel = new SaveCategoryViewModel();
            
            return await InitializeCategoryFormView(categoryViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
                return NotFound();

            var categoryViewModel = _mapper.Map<SaveCategoryViewModel>(category);

            return await InitializeCategoryFormView(categoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([FromForm] SaveCategoryViewModel categoryViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("CategoryForm", categoryViewModel);
                }

                if (categoryViewModel.Id == 0)
                    await _categoryService.CreateNewCategory(categoryViewModel);
                else
                    await _categoryService.UpdateCategory(categoryViewModel.Id, categoryViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CategoryForm", categoryViewModel);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _categoryService.DeleteCategory(id);
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
        private async Task<IActionResult> InitializeCategoryFormView(SaveCategoryViewModel categoryViewModel)
        {
            var subCategories = await _subCategoryService.GetSubCategoriesUsingStoredProcedure(categoryViewModel.Id);
            categoryViewModel.SubCategories = new SelectList(subCategories, "Id", "Name");

            return View("CategoryForm", categoryViewModel);
        }

    }
}
