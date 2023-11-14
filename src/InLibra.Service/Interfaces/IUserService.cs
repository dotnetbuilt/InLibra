using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.Users;

namespace InLibra.Service.Interfaces;

public interface IUserService
{
    ValueTask<UserResultDto> AddAsync(UserCreationDto dto);
    ValueTask<UserResultDto> UpdateAsync(UserUpdateDto dto);
    ValueTask<bool> RemoveAsync(long userId);
    ValueTask<UserResultDto> RetrieveByIdAsync(long userId);
    ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync();
}