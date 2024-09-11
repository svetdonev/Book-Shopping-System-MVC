using AutoMapper;
using BookShoppingSystemMVC.Models;

namespace BookShoppingSystemMVC.Mapping
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            this.CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookName))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.BookImage, opt => opt.MapFrom(src => src.BookImage))
                .ForMember(dest => dest.BookPrice, opt => opt.MapFrom(src => src.BookPrice));

            this.CreateMap<Genre, GenreDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenreName));
        }
    }
}
