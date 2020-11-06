namespace Locadora.Filmes.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoAltTabFilme : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Filmes", newName: "Filme");
            DropForeignKey("dbo.Filmes", "album_Id", "dbo.Album");
            DropIndex("dbo.Filme", new[] { "album_Id" });
            DropColumn("dbo.Filme", "IdAlbum");
            RenameColumn(table: "dbo.Filme", name: "album_Id", newName: "IdAlbum");
            AlterColumn("dbo.Filme", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Filme", "IdAlbum", c => c.Int(nullable: false));
            CreateIndex("dbo.Filme", "IdAlbum");
            AddForeignKey("dbo.Filme", "IdAlbum", "dbo.Album", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filme", "IdAlbum", "dbo.Album");
            DropIndex("dbo.Filme", new[] { "IdAlbum" });
            AlterColumn("dbo.Filme", "IdAlbum", c => c.Int());
            AlterColumn("dbo.Filme", "Nome", c => c.String());
            RenameColumn(table: "dbo.Filme", name: "IdAlbum", newName: "album_Id");
            AddColumn("dbo.Filme", "IdAlbum", c => c.Int(nullable: false));
            CreateIndex("dbo.Filme", "album_Id");
            AddForeignKey("dbo.Filmes", "album_Id", "dbo.Album", "Id");
            RenameTable(name: "dbo.Filme", newName: "Filmes");
        }
    }
}
