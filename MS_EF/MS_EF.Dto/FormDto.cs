using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_EF.Dto
{
    public class FormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<InputDto> Inputs { get; set; } = new List<InputDto>();
    }
}
