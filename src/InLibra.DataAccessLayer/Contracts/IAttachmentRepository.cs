using InLibra.DataAccessLayer.Contexts;
using InLibra.Domain.Entities;

namespace InLibra.DataAccessLayer.Contracts;

public interface IAttachmentRepository
{
    ValueTask CreateAsync(Attachment attachment);
    void Delete(Attachment attachment);
    ValueTask<Attachment> SelectByIdAsync(long attachmentId);
}