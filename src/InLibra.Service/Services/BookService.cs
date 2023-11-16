using AutoMapper;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.Books;
using InLibra.Service.Exceptions;
using InLibra.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InLibra.Service.Services;

public class BookService:IBookService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Book> _repository;
    private readonly IGenericRepository<User> _userRepo;
    private readonly IAttachmentRepository _attachmentRepo;
    private readonly ILanguageRepository _languageRepo;

    public BookService(IMapper mapper, 
                       IGenericRepository<Book> repository,
                       IGenericRepository<User> userRepo,
                       IAttachmentRepository attachmentRepo,
                       ILanguageRepository languageRepo)
    {
        _mapper = mapper;
        _repository = repository;
        _userRepo = userRepo;
        _attachmentRepo = attachmentRepo;
        _languageRepo = languageRepo;
    }

    public async ValueTask<BookResultDto> AddAsync(BookCreationDto dto)
    {
        var user = await _userRepo.SelectAsync(expression: user => user.Id == dto.UserId)
                   ?? throw new NotFoundException(message: "User is not found");

        var attachment = await _attachmentRepo.SelectByIdAsync(dto.AttachmentId)
                         ?? throw new NotFoundException(message: "Attachment is not found");

        var language = await _languageRepo.SelectAsync(expression: language => language.Id == dto.LanguageId)
                       ?? throw new NotFoundException(message: "Language is not found");

        var newBook = _mapper.Map<Book>(source: dto);
        newBook.Attachment = attachment;
        newBook.AttachmentId = attachment.Id;
        newBook.User = user;
        newBook.UserId = user.Id;
        newBook.Language = language;
        newBook.LanguageId = language.Id;

        await _repository.CreateAsync(entity: newBook);

        return _mapper.Map<BookResultDto>(source: newBook);
    }

    public async ValueTask<BookResultDto> UpdateAsync(BookUpdateDto dto)
    {
        var book = await _repository.SelectAsync(expression: book => book.Id == dto.Id)
                   ?? throw new NotFoundException(message: "Book is not found");

        _mapper.Map(source: dto, destination: book);
        
        _repository.Update(entity:book);

        return _mapper.Map<BookResultDto>(source: book);
    }

    public async ValueTask<bool> RemoveAsync(long bookId)
    {
        var book = await _repository.SelectAsync(expression: book => book.Id == bookId)
                   ?? throw new NotFoundException(message: "Book is not found");
        
        _repository.Delete(entity:book);

        return true;
    }

    public async ValueTask<BookResultDto> RetrieveByIdAsync(long bookId)
    {
        var book = await _repository.SelectAsync(expression: book => book.Id == bookId)
                   ?? throw new NotFoundException(message: "Book is not found");

        return _mapper.Map<BookResultDto>(source: book);
    }

    public async ValueTask<IEnumerable<BookResultDto>> RetrieveAllAsync()
    {
        var books = await _repository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<BookResultDto>>(source: books);
    }
}