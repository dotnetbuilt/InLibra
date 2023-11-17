using InLibra.Service.Interfaces;
using InLibra.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InLibra.WebApi.Controllers;

public class AttachmentsController : BaseController
{
    private readonly IAttachmentService _service;

    public AttachmentsController(IAttachmentService service)
    {
        _service = service;
    }

    [HttpPost("upload")]
    public async ValueTask<IActionResult> UploadAsync(IFormFile file)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.UploadAsync(file)
        });

    [HttpDelete("delete")]
    public async ValueTask<IActionResult> DeleteAsync(long attachmentId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RemoveAsync(attachmentId)
        });

    [HttpGet("get-by-id")]
    public async ValueTask<IActionResult> GetByIdAsync(long attachmentId)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _service.RetrieveByIdAsync(attachmentId)
        });
}