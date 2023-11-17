using AutoMapper;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.BookShelves;
using InLibra.Service.Exceptions;
using InLibra.Service.Interfaces;

namespace InLibra.Service.Services;

public class BookShelfService : IBookShelfService
{
    private readonly IMapper _mapper;
    private readonly IBookShelfRepository _repository;
    private readonly IGenericRepository<Book> _bookRepo;
    private readonly IGenericRepository<Shelf> _shelfRepo;

    public BookShelfService(IMapper mapper, IBookShelfRepository repository, IGenericRepository<Book> bookRepo, IGenericRepository<Shelf> shelfRepo)
    {
        _mapper = mapper;
        _repository = repository;
        _bookRepo = bookRepo;
        _shelfRepo = shelfRepo;
    }

    public async ValueTask<BookShelfResultDto> AddAsync(BookShelfCreationDto dto)
    {
        var book = await _bookRepo.SelectAsync(expression: book => book.Id == dto.BookId)
                   ?? throw new NotFoundException(message: "Book is not found");

        var shelf = await _shelfRepo.SelectAsync(expression: shelf => shelf.Id == dto.ShelfId)
                    ?? throw new NotFoundException(message: "Shelf is not found");

        var bookShelf = await _repository.SelectAsync(expression: bookShelf => bookShelf.ShelfId == dto.ShelfId &&
                                                                               bookShelf.BookId == dto.BookId);

        if (bookShelf != null)
            throw new AlreadyExistsException(message: "BookShelf is already exist");

        var newBookShelf = _mapper.Map<BookShelf>(source: dto);
        newBookShelf.BookId = book.Id;
        newBookShelf.Book = book;
        newBookShelf.ShelfId = shelf.Id;
        newBookShelf.Shelf = shelf;

        await _repository.CreateAsync(newBookShelf);

        return _mapper.Map<BookShelfResultDto>(source: newBookShelf);
    }

    public async ValueTask<bool> RemoveAsync(long bookShelfId)
    {
        var bookShelf = await _repository.SelectAsync(expression: bookShelf => bookShelf.Id == bookShelfId)
                        ?? throw new NotFoundException(message: "BookShelf is not found");
        
        _repository.Delete(bookShelf);

        return true;
    }

    public async ValueTask<BookShelfResultDto> RetrieveByIdAsync(long bookShelfId)
    {
        var bookShelf = await _repository.SelectAsync(expression: bookShelf => bookShelf.Id == bookShelfId)
                        ?? throw new NotFoundException(message: "BookShelf is not found");

        return _mapper.Map<BookShelfResultDto>(source: bookShelf);
    }
}