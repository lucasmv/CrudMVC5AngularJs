namespace CrudMVC5AngularJs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Celular",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(maxLength: 50, unicode: false),
                        Modelo = c.String(maxLength: 50, unicode: false),
                        Cor = c.String(maxLength: 50, unicode: false),
                        TipoChip = c.String(maxLength: 50, unicode: false),
                        MemoriaInterna = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50, unicode: false),
                        Telefone = c.String(maxLength: 50, unicode: false),
                        Data = c.DateTime(nullable: false),
                        OperadoraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Operadora", t => t.OperadoraId)
                .Index(t => t.OperadoraId);
            
            CreateTable(
                "dbo.Operadora",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50, unicode: false),
                        Codigo = c.Int(nullable: false),
                        Categoria = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contato", "OperadoraId", "dbo.Operadora");
            DropIndex("dbo.Contato", new[] { "OperadoraId" });
            DropTable("dbo.Operadora");
            DropTable("dbo.Contato");
            DropTable("dbo.Celular");
        }
    }
}
