using InLibra.DataAccessLayer.Contexts;
using InLibra.DataAccessLayer.Contracts;
using InLibra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InLibra.DataAccessLayer.Repositories;

public class AttachmentRepository:IAttachmentRepository
{
    private readonly InLibraContext _context;

    public AttachmentRepository(InLibraContext context)
    {
        _context = context;
    }

    public async ValueTask CreateAsync(Attachment attachment)
    {
        await _context.Attachments.AddAsync(attachment);
        await _context.SaveChangesAsync();
    }

    public void Delete(Attachment attachment)
    {
        _context.Attachments.Remove(attachment);
        _context.SaveChanges();
    }

    public async ValueTask<Attachment> SelectByIdAsync(long attachmentId)
        => await _context.Attachments.FirstOrDefaultAsync(attachment => attachment.Id == attachmentId);
}