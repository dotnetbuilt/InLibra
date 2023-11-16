using InLibra.Service.DTOs.BookGenres;

namespace InLibra.Service.Interfaces;

public interface IBookGenreService
{
    ValueTask<BookGenreResultDto> AddAsync(BookGenreCreationDto dto);
    ValueTask<bool> RemoveAsync(long bookGenreId);
}