namespace Projeto_Final_TCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fotos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fotos",
                c => new
                    {
                        FotoId = c.Int(nullable: false, identity: true),
                        ID_Usuario = c.Int(nullable: false),
                        ID_Animal = c.Int(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        ID_Verificado = c.Int(nullable: false),
                        Imagem = c.Binary(),
                        OBs = c.String(),
                    })
                .PrimaryKey(t => t.FotoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fotos");
        }
    }
}
