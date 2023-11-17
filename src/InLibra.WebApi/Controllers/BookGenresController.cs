using InLibra.Service.DTOs.BookGenres;
using InLibra.Service.Interfaces;
using InLibra.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InLibra.WebApi.Controllers;

public class BookGenresController:BaseController
{
    private readonly IBookGenreService _service;

    public BookGenresController(IBookGenreService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateAsync(BookGenreCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.AddAsync(dto)
        });

    [HttpPost("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long bookGenreId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(bookGenreId)
        });
}