namespace Locadora.Filmes.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Ano = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        Autor = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        IdAlbum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.IdAlbum, cascadeDelete: true)
                .Index(t => t.IdAlbum);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filme", "IdAlbum", "dbo.Album");
            DropIndex("dbo.Filme", new[] { "IdAlbum" });
            DropTable("dbo.Filme");
            DropTable("dbo.Album");
        }
    }
}
