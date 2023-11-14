using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.Users;
using InLibra.Service.Interfaces;

namespace InLibra.Service.Services;

public class UserService:IUserService
{
    private readonly IGenericRepository<User> _repository;

    public UserService(IGenericRepository<User> repository)
    {
        _repository = repository;
    }

    public async ValueTask<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var user = await _repository.SelectAsync(expression: user => user.Email == dto.Email);
        
        if(user != 
    }

    public async ValueTask<UserResultDto> UpdateAsync(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> RemoveAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<UserResultDto> RetrieveByIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<IEnumerable<UserResultDto>> RetrieveAll()
    {
        throw new NotImplementedException();
    }
}