using AutoMapper;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.Users;
using InLibra.Service.Exceptions;
using InLibra.Service.Helpers;
using InLibra.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InLibra.Service.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _repository;
    private readonly IMapper _mapper;

    public UserService(IGenericRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async ValueTask<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var user = await _repository.SelectAsync(expression: user => user.Email == dto.Email);

        if (user != null)
            throw new AlreadyExistsException(message: "Email is already taken");

        var newUser = _mapper.Map<User>(source: dto);
        newUser.Password = PasswordHasher.Hash(dto.Password);

        await _repository.CreateAsync(entity: newUser);

        return _mapper.Map<UserResultDto>(source: newUser);
    }

    public async ValueTask<UserResultDto> UpdateAsync(UserUpdateDto dto)
    {
        var user = await _repository.SelectAsync(expression: user => user.Id == dto.Id)
                   ?? throw new NotFoundException(message: "User is not found");

        _mapper.Map(source: dto, destination: user);

        _repository.Update(entity: user);

        return _mapper.Map<UserResultDto>(source: user);
    }

    public async ValueTask<bool> RemoveAsync(long userId)
    {
        var user = await _repository.SelectAsync(expression: user => user.Id == userId)
                   ?? throw new NotFoundException(message: "User is not found");

        _repository.Delete(entity: user);

        return true;
    }

    public async ValueTask<UserResultDto> RetrieveByIdAsync(long userId)
    {
        var user = await _repository.SelectAsync(expression: user => user.Id == userId)
                   ?? throw new NotFoundException(message: "User is not found");

        return _mapper.Map<UserResultDto>(source: user);
    }

    public async ValueTask<IEnumerable<UserResultDto>> RetrieveAllAsync()
    {
        var users = await _repository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<UserResultDto>>(source: users);
    }
}