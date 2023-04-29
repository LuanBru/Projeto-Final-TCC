using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Final_TCC.Models
{
    public class Fotos
    {
        public int ID_Foto { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Animal { get; set; }
        public string GPS { get; set; }
        public int ID_Verificado { get; set; }
        public string OBs { get; set; }

    }
}