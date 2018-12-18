namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdcionarListaProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.Produtoes", "Categoria_Id");
            AddForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "Categoria_Id" });
            DropColumn("dbo.Produtoes", "Categoria_Id");
        }
    }
}
