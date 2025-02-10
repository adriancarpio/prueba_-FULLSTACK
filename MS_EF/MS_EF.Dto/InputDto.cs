using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_EF.Dto
{
    public class InputDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
    }
}
