using MS_EF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_EF.Domain.Interface
{
    public interface IInputRepository
    {
        Task<IEnumerable<Input>> GetAllAsync();
        Task<Input> GetByIdAsync(int id);
        Task AddAsync(Input input);
        Task<bool> DeleteAsync(int id);
    }
}
