namespace ProjetoAspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _000_Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cadernoes",
                c => new
                    {
                        CadernoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CadernoId);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        NotasId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Tag = c.String(),
                        DataDaCriacao = c.DateTime(nullable: false),
                        Conteudo = c.String(),
                    })
                .PrimaryKey(t => t.NotasId);
            
            CreateTable(
                "dbo.NotasCadernoes",
                c => new
                    {
                        Notas_NotasId = c.Int(nullable: false),
                        Caderno_CadernoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Notas_NotasId, t.Caderno_CadernoId })
                .ForeignKey("dbo.Notas", t => t.Notas_NotasId, cascadeDelete: true)
                .ForeignKey("dbo.Cadernoes", t => t.Caderno_CadernoId, cascadeDelete: true)
                .Index(t => t.Notas_NotasId)
                .Index(t => t.Caderno_CadernoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotasCadernoes", "Caderno_CadernoId", "dbo.Cadernoes");
            DropForeignKey("dbo.NotasCadernoes", "Notas_NotasId", "dbo.Notas");
            DropIndex("dbo.NotasCadernoes", new[] { "Caderno_CadernoId" });
            DropIndex("dbo.NotasCadernoes", new[] { "Notas_NotasId" });
            DropTable("dbo.NotasCadernoes");
            DropTable("dbo.Notas");
            DropTable("dbo.Cadernoes");
        }
    }
}
