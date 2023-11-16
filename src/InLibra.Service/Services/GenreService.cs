using AutoMapper;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.Genres;
using InLibra.Service.Exceptions;
using InLibra.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InLibra.Service.Services;

public class GenreService:IGenreService
{
    private readonly IMapper _mapper;
    private readonly IGenreRepository _repository;

    public GenreService(IMapper mapper, IGenreRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async ValueTask<GenreResultDto> AddAsync(GenreCreationDto dto)
    {
        var genre = await _repository.SelectAsync(expression: genre => genre.Name == dto.Name);

        if (genre != null)
            throw new AlreadyExistsException(message: "Genre is already exist");

        var newGenre = _mapper.Map<Genre>(source: dto);

        await _repository.CreateAsync(newGenre);

        return _mapper.Map<GenreResultDto>(source: newGenre);
    }

    public async ValueTask<bool> RemoveAsync(long genreId)
    {
        var genre = await _repository.SelectAsync(expression: genre => genre.Id == genreId)
            ?? throw new NotFoundException(message:"Genre is not found");
        
        _repository.Delete(genre);

        return true;
    }

    public async ValueTask<GenreResultDto> RetrieveByIdAsync(long genreId)
    {
        var genre = await _repository.SelectAsync(expression: genre => genre.Id == genreId)
                    ?? throw new NotFoundException(message:"Genre is not found");

        return _mapper.Map<GenreResultDto>(source: genre);
    }

    public async ValueTask<IEnumerable<GenreResultDto>> RetrieveAllAsync()
    {
        var genres = await _repository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<GenreResultDto>>(source: genres);
    }
}