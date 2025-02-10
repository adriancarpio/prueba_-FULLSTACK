using MS_EF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_EF.Domain.Interface
{
    public interface IFormRepository
    {
        Task<IEnumerable<Form>> GetFormsAsync();
        Task<Form> GetFormByIdAsync(int id);
        Task<Form> CreateFormAsync(Form form);
        Task<Form> UpdateFormAsync(Form form);
        Task<bool> DeleteFormAsync(int id);
    }
}
