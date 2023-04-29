using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Final_TCC.Models
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ID_Bio { get; set; }

        public string V_Biologo { get; set; }
    }
}