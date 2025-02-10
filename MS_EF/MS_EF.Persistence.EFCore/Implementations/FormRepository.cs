using Npgsql;
using MS_EF.Domain.Entity;
using MS_EF.Domain.Interface;

using MS_EF.Persistence.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MS_EF.Persistence.EFCore.Implementations
{
    public class FormRepository : IFormRepository
    {
        private readonly ApplicationDbContext _context;

        public FormRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Form>> GetFormsAsync()
        {
            return await _context.Forms.Include(f => f.Inputs).ToListAsync();
        }

        public async Task<Form> GetFormByIdAsync(int id)
        {
            return await _context.Forms.Include(f => f.Inputs).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Form> CreateFormAsync(Form form)
        {
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<Form> UpdateFormAsync(Form form)
        {
            _context.Forms.Update(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<bool> DeleteFormAsync(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null) return false;

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
