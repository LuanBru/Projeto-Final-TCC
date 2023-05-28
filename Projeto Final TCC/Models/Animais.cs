using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Final_TCC.Models
{
    public class Animais
    {
        private readonly static string _conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = AgenciaAuto; Integrated Security = True; Connect Timeout = 30;
Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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