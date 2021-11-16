using AutoMapper;
using LibrarySystem.Core.Models;
using LibrarySystem.ViewModels.Author;

namespace LibrarySystem.MappingProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Author, SaveAuthorViewModel>().ReverseMap();
            CreateMap<AuthorViewModel, SaveAuthorViewModel>().ReverseMap();
        }
    }
}
