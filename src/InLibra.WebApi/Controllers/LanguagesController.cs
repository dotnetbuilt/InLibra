using InLibra.Service.DTOs.Languages;
using InLibra.Service.Interfaces;
using InLibra.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InLibra.WebApi.Controllers;

public class LanguagesController:BaseController
{
    private readonly ILanguageService _service;

    public LanguagesController(ILanguageService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(LanguageCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long languageId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(languageId)
        });

    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long languageId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(languageId)
        });

    [HttpGet("get-all")]
    public async ValueTask<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveAllAsync()
        });
}