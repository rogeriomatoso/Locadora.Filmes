namespace Locadora.Filmes.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoTabFilme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filmes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        IdAlbum = c.Int(nullable: false),
                        album_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.album_Id)
                .Index(t => t.album_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filmes", "album_Id", "dbo.Album");
            DropIndex("dbo.Filmes", new[] { "album_Id" });
            DropTable("dbo.Filmes");
        }
    }
}
