using AutoMapper;
using LibrarySystem.Core.Models;
using LibrarySystem.ViewModels.Book;

namespace LibrarySystem.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.SubCategory.CategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                .ReverseMap();
            CreateMap<Book, SaveBookViewModel>().ReverseMap();
            CreateMap<BookViewModel, SaveBookViewModel>().ReverseMap();
        }
    }
}
