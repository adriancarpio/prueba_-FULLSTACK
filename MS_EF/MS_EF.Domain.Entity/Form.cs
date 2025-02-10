using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_EF.Domain.Entity
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Input> Inputs { get; set; } = new List<Input>();
    }
}
