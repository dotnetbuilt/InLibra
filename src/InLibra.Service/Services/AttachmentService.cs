using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using InLibra.Service.Exceptions;
using InLibra.Service.Extensions;
using InLibra.Service.Helpers;
using InLibra.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace InLibra.Service.Services;

public class AttachmentService:IAttachmentService
{
    private readonly IAttachmentRepository _repository;

    public AttachmentService(IAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<Attachment> UploadAsync(IFormFile formFile)
    {
        var webRootPath = Path.Combine(PathHelper.WebRootPath, "Images");

        if (!Directory.Exists(webRootPath))
            Directory.CreateDirectory(webRootPath);

        var fileName = MediaHelper.MakeImageName(formFile.FileName);
        var filePath = Path.Combine(webRootPath, fileName);

        var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(formFile.ToByte());

        var createdAttachment = new Attachment
        {
            Filename = fileName,
            Filepath = filePath
        };

        await _repository.CreateAsync(createdAttachment);

        return createdAttachment;
    }

    public async ValueTask<bool> RemoveAsync(long attachmentId)
    {
        var file = await _repository.SelectByIdAsync(attachmentId)
            ?? throw new NotFoundException(message:"File is not found");
        
        _repository.Delete(file);

        return true;
    }

    public async ValueTask<Attachment> RetrieveByIdAsync(long attachmentId)
    {
        var file = await _repository.SelectByIdAsync(attachmentId)
                   ?? throw new NotFoundException(message:"File is not found");

        return file;
    }
}