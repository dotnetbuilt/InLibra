using AutoMapper;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.DTOs.Languages;
using InLibra.Service.Exceptions;
using InLibra.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InLibra.Service.Services;

public class LanguageService:ILanguageService
{
    private readonly IMapper _mapper;
    private readonly ILanguageRepository _repository;

    public LanguageService(IMapper mapper, ILanguageRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async ValueTask<LanguageResultDto> AddAsync(LanguageCreationDto dto)
    {
        var language = await _repository
            .SelectAsync(expression: language => language.Name == dto.Name && language.Code == dto.Code);

        if (language != null)
            throw new AlreadyExistsException(message: "Language already exists");

        var newLanguage = _mapper.Map<Language>(source: dto);

        await _repository.CreateAsync(newLanguage);

        return _mapper.Map<LanguageResultDto>(source: newLanguage);
    }

    public async ValueTask<bool> RemoveAsync(long languageId)
    {
        var language = await _repository
                           .SelectAsync(expression: language => language.Id == languageId)
                       ?? throw new NotFoundException(message: "Language is not found");
        
        _repository.Delete(language);

        return true;
    }

    public async ValueTask<LanguageResultDto> RetrieveByIdAsync(long languageId)
    {
        var language = await _repository
                           .SelectAsync(expression: language => language.Id == languageId)
                       ?? throw new NotFoundException(message: "Language is not found");

        return _mapper.Map<LanguageResultDto>(source: language);
    }

    public async ValueTask<IEnumerable<LanguageResultDto>> RetrieveAllAsync()
    {
        var languages = await _repository.SelectAll().ToListAsync();

        return _mapper.Map<IEnumerable<LanguageResultDto>>(source: languages);
    }
}