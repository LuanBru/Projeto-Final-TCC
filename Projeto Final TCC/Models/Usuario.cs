using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Final_TCC.Models
{
    public class Usuario
    {
        [Key]
        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


    }

    public class Bio
    {
        [Key]
        public int Id_bio { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


    }

    public class ADM
    {
        [Key]
        public int Id_adm { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


    }

}
