using InLibra.Service.DTOs.Genres;

namespace InLibra.Service.Interfaces;

public interface IGenreService
{
    ValueTask<GenreResultDto> AddAsync(GenreCreationDto dto);
    ValueTask<bool> RemoveAsync(long genreId);
    ValueTask<GenreResultDto> RetrieveByIdAsync(long genreId);
    ValueTask<IEnumerable<GenreResultDto>> RetrieveAllAsync();
}