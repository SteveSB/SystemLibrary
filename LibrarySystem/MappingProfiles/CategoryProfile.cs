using AutoMapper;
using LibrarySystem.Core.Models;
using LibrarySystem.ViewModels.Category;

namespace LibrarySystem.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, SaveCategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, SaveCategoryViewModel>().ReverseMap();
        }
    }
}
