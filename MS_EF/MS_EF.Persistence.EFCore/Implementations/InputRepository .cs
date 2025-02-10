using Npgsql;
using MS_EF.Domain.Entity;
using MS_EF.Domain.Interface;

using MS_EF.Persistence.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MS_EF.Persistence.EFCore.Implementations
{
    public class InputRepository : IInputRepository
    {
        private readonly ApplicationDbContext _context;

        public InputRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Input>> GetAllAsync()
        {
            return await _context.Inputs.ToListAsync();
        }

        public async Task<Input> GetByIdAsync(int id)
        {
            return await _context.Inputs.FindAsync(id);
        }

        public async Task AddAsync(Input input)
        {
            await _context.Inputs.AddAsync(input);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null) return false;

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
