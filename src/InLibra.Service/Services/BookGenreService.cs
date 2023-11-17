using AutoMapper;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.BookGenres;
using InLibra.Service.Exceptions;
using InLibra.Service.Interfaces;

namespace InLibra.Service.Services;

public class BookGenreService:IBookGenreService
{
    private readonly IMapper _mapper;
    private readonly IBookGenreRepository _repository;
    private readonly IGenericRepository<Book> _bookRepo;
    private readonly IGenreRepository _genreRepo;

    public BookGenreService(IMapper mapper, 
                            IBookGenreRepository repository, 
                            IGenericRepository<Book> bookRepo,
                            IGenreRepository genreRepo)
    {
        _mapper = mapper;
        _repository = repository;
        _bookRepo = bookRepo;
        _genreRepo = genreRepo;
    }
    
    public async ValueTask<BookGenreResultDto> AddAsync(BookGenreCreationDto dto)
    {
        var book = await _bookRepo.SelectAsync(expression: book => book.Id == dto.BookId)
                   ?? throw new NotFoundException(message: "Book is not found");

        var genre = await _genreRepo.SelectAsync(expression: genre => genre.Id == dto.GenreId)
                    ?? throw new NotFoundException(message: "Genre is not found");

        var bookGenre = await _repository.SelectAsync(expression: bookGenre => bookGenre.BookId == dto.BookId &&
                                                                               bookGenre.GenreId == dto.GenreId);

        if (bookGenre != null)
            throw new AlreadyExistsException(message: "BookGenre is already exist");

        var newBookGenre = _mapper.Map<BookGenre>(source: dto);
        newBookGenre.Book = book;
        newBookGenre.BookId = book.Id;
        newBookGenre.Genre = genre;
        newBookGenre.GenreId = genre.Id;

        await _repository.CreateAsync(newBookGenre);

        return _mapper.Map<BookGenreResultDto>(source: newBookGenre);
    }

    public async ValueTask<bool> RemoveAsync(long bookGenreId)
    {
        var bookGenre = await _repository.SelectAsync(expression: bookGenre => bookGenre.Id == bookGenreId)
                        ?? throw new NotFoundException(message: "BookGenre is not found");
        
        _repository.Delete(bookGenre);

        return true;
    }
}