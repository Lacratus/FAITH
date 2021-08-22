using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.DTOs
{
    public class VerdiepingDTO
    {
        [Required]
        public string Beschrijving { get; set; }
        public List<string> Tussenstappen { get; set; }
    }
}
