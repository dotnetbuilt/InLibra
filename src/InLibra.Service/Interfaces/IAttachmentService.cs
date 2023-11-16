using InLibra.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace InLibra.Service.Interfaces;

public interface IAttachmentService
{
    ValueTask<Attachment> UploadAsync(IFormFile formFile);
    ValueTask<bool> RemoveAsync(long attachmentId);
    ValueTask<Attachment> RetrieveByIdAsync(long attachmentId);
}