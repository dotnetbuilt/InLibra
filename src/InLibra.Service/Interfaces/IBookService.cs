using InLibra.Domain.Entities;
using InLibra.Service.DTOs.BookGenres;
using InLibra.Service.DTOs.Books;

namespace InLibra.Service.Interfaces;

public interface IBookService
{
    ValueTask<BookResultDto> AddAsync(BookCreationDto dto);
    ValueTask<BookResultDto> UpdateAsync(BookUpdateDto dto);
    ValueTask<bool> RemoveAsync(long bookId);
    ValueTask<BookResultDto> RetrieveByIdAsync(long bookId);
    ValueTask<IEnumerable<BookResultDto>> RetrieveAllAsync();
}