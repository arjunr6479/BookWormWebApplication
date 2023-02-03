using AutoMapper;
using BookWormWebApp.Model.DTO;
using BookWormWebAPP.Model.Domain;
using BookWormWebAPP.Model.DTO;

namespace BookWormWebApp.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDetails, BookDto>().ReverseMap();
            CreateMap<AuthorDetails, AddAuthorDto>().ReverseMap();
            CreateMap<AuthorDetails, UpdateAuthorDto>().ReverseMap();
            CreateMap<CategoryDetails, AddCategoryDto>().ReverseMap();
            CreateMap<CategoryDetails, UpdateAuthorDto>().ReverseMap();
            CreateMap<BookDetails, AddBookDto>().ReverseMap();
            CreateMap<BookDetails, UpdateBookDto>().ReverseMap();

        }

    }
}
