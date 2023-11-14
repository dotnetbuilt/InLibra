using Microsoft.AspNetCore.Http;

namespace InLibra.Service.DTOs.Attachments;

public class AttachmentCreationDto
{
    public IFormFile File { get; set; }
}