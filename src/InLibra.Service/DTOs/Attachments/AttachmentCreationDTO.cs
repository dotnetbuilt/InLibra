using Microsoft.AspNetCore.Http;

namespace InLibra.Service.DTOs.Attachments;

public class AttachmentCreationDTO
{
    public IFormFile File { get; set; }
}