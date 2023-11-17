using InLibra.Service.DTOs.BookShelves;

namespace InLibra.Service.Interfaces;

public interface IBookShelfService
{
    ValueTask<BookShelfResultDto> AddAsync(BookShelfCreationDto dto);
    ValueTask<bool> RemoveAsync(long bookShelfId);
    ValueTask<BookShelfResultDto> RetrieveByIdAsync(long bookShelfId);
}