using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_EF.Domain.Entity
{
    public class Input
    {
        [Key]
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }

        public Form Form { get; set; }
    }
}
