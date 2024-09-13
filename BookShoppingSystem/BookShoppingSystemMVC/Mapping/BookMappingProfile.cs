using AutoMapper;
using BookShoppingSystemMVC.Models;

namespace BookShoppingSystemMVC.Mapping
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<BookCreateRequest, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Genre, opt => opt.Ignore()); // Handle Genre in the service

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));

            CreateMap<Genre, GenreDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
