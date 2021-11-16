using AutoMapper;
using LibrarySystem.Core.Models;
using LibrarySystem.ViewModels.Book;

namespace LibrarySystem.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Book, SaveBookViewModel>().ReverseMap();
            CreateMap<BookViewModel, SaveBookViewModel>().ReverseMap();
        }
    }
}
