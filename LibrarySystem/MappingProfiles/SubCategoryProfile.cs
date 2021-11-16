using AutoMapper;
using LibrarySystem.Core.Models;
using LibrarySystem.ViewModels.SubCategory;

namespace LibrarySystem.MappingProfiles
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategory, SubCategoryViewModel>().ReverseMap();
            CreateMap<SubCategory, SaveSubCategoryViewModel>().ReverseMap();
            CreateMap<SubCategoryViewModel, SaveSubCategoryViewModel>().ReverseMap();
        }
    }
}
