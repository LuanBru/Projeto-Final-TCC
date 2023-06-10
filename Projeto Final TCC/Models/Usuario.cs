using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Final_TCC.Models
{
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string ID_Bio { get; set; }

        public bool V_Biologo { get; set; }
    }
}