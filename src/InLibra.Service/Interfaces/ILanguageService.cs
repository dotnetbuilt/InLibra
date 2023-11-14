using AutoMapper;
using InLibra.Service.DTOs.Languages;

namespace InLibra.Service.Interfaces;

public interface ILanguageService
{
    ValueTask<LanguageResultDto> AddAsync(LanguageCreationDto dto);
    ValueTask<bool> RemoveAsync(long languageId);
    ValueTask<LanguageResultDto> RetrieveByIdAsync(long languageId);
    ValueTask<IEnumerable<LanguageResultDto>> RetrieveAllAsync();
}