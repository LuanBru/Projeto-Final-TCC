using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Final_TCC.Models
{
    public class Animais
    {


        public int ID_Animal { get; set; }
        public string Esp { get; set; }
        public string Curio { get; set; }

        public Animais(int id, string esp, string curio)
        {
            ID_Animal = id;
            Esp = esp;
            Curio = curio;

        }

    }


    
}