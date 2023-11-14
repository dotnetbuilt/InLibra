using AutoMapper;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.BookGenres;
using InLibra.Service.DTOs.Books;
using InLibra.Service.DTOs.Genres;
using InLibra.Service.DTOs.Languages;
using InLibra.Service.DTOs.Shelves;
using InLibra.Service.DTOs.Users;

namespace InLibra.Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        //BookGenre
        CreateMap<BookGenre, BookGenreCreationDto>().ReverseMap();
        CreateMap<BookGenre, BookGenreResultDto>().ReverseMap();
        
        //Book
        CreateMap<Book, BookCreationDto>().ReverseMap();
        CreateMap<Book, BookUpdateDto>().ReverseMap();
        CreateMap<Book, BookResultDto>().ReverseMap();
        
        //Genre
        CreateMap<Genre, GenreCreationDto>().ReverseMap();
        CreateMap<Genre, GenreResultDto>().ReverseMap();
        
        //Language
        CreateMap<Language, LanguageCreationDto>().ReverseMap();
        CreateMap<Language, LanguageResultDto>().ReverseMap();
        
        //Shelf
        CreateMap<Shelf, ShelfCreationDto>().ReverseMap();
        CreateMap<Shelf, ShelfUpdateDto>().ReverseMap();
        CreateMap<Shelf, ShelfResultDto>().ReverseMap();
        
        //User
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();
    }
}