using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Final_TCC.Models
{
    public class Fotos
    {
        [Key]
        public int FotoId { get; set; }
        public byte[] ImagemCache { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Animal { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int ID_Verificado { get; set; }
        public string OBs { get; set; }





        public class DTB1 : DbContext
        {
            public static object Usuarios { get; internal set; }
            public DbSet<Fotos> Foto { get; set; }
            public DbSet<Usuario> usuario { get; set; }
            public DbSet<Bio> biologo { get; set; }
            public DbSet<ADM> administrador { get; set; }
        }


    }
}