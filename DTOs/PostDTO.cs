using FAITHAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.DTOs
{
    public class PostDTO
    {
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        [Required]
        public string GebruikerEmail { get; set; }
    }
}
