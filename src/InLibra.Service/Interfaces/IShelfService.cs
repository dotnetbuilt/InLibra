using InLibra.Service.DTOs.Shelves;

namespace InLibra.Service.Interfaces;

public interface IShelfService
{
    ValueTask<ShelfResultDto> AddAsync(ShelfCreationDto dto);
    ValueTask<ShelfResultDto> UpdateAsync(ShelfUpdateDto dto);
    ValueTask<bool> RemoveAsync(long shelfId);
    ValueTask<ShelfResultDto> RetrieveByIdAsync(long shelfId);
    ValueTask<IEnumerable<ShelfResultDto>> RetrieveAllAsync();
}