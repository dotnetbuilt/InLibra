using AutoMapper;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.Shelves;
using InLibra.Service.Exceptions;
using InLibra.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InLibra.Service.Services;

public class ShelfService:IShelfService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Shelf> _repository;
    private readonly IGenericRepository<User> _userRepo;

    public ShelfService(IMapper mapper, 
                        IGenericRepository<Shelf> repository,
                        IGenericRepository<User> userRepo)
    {
        _mapper = mapper;
        _repository = repository;
        _userRepo = userRepo;
    }

    public async ValueTask<ShelfResultDto> AddAsync(ShelfCreationDto dto)
    {
        var user = await _userRepo.SelectAsync(expression: user => user.Id == dto.UserId)
                   ?? throw new NotFoundException(message: "User is not found");

        var shelf = await _repository.SelectAsync(expression: shelf => shelf.Name == dto.Name);

        if (shelf != null)
            throw new AlreadyExistsException(message: "Shelf is already exist");

        var newShelf = _mapper.Map<Shelf>(source: dto);
        newShelf.User = user;
        newShelf.UserId = user.Id;

        await _repository.CreateAsync(entity: newShelf);

        return _mapper.Map<ShelfResultDto>(source: newShelf);
    }

    public async ValueTask<ShelfResultDto> UpdateAsync(ShelfUpdateDto dto)
    {
        var shelf = await _repository.SelectAsync(expression: shelf => shelf.Id == dto.Id)
                    ?? throw new NotFoundException(message: "Shelf is not found");

        _mapper.Map(source: dto, destination: shelf);
        
        _repository.Update(shelf);

        return _mapper.Map<ShelfResultDto>(source: shelf);
    }

    public async ValueTask<bool> RemoveAsync(long shelfId)
    {
        var shelf = await _repository.SelectAsync(expression: shelf => shelf.Id == shelfId)
                    ?? throw new NotFoundException(message: "Shelf is not found");
        
        _repository.Delete(entity:shelf);

        return true;
    }

    public async ValueTask<ShelfResultDto> RetrieveByIdAsync(long shelfId)
    {
        var shelf = await _repository.SelectAsync(expression: shelf => shelf.Id == shelfId)
                    ?? throw new NotFoundException(message: "Shelf is not found");

        return _mapper.Map<ShelfResultDto>(source: shelf);
    }

    public async ValueTask<IEnumerable<ShelfResultDto>> RetrieveAllAsync()
    {
        var shelves = await _repository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<ShelfResultDto>>(source: shelves);
    }
}