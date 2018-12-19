namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigidoentidadeCmpraItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "CompraItem_Id", "dbo.CompraItens");
            DropIndex("dbo.Produtos", new[] { "CompraItem_Id" });
            AddColumn("dbo.CompraItens", "PrecoUnitario", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CompraItens", "ProdutoID", c => c.Int(nullable: false));
            CreateIndex("dbo.CompraItens", "ProdutoID");
            AddForeignKey("dbo.CompraItens", "ProdutoID", "dbo.Produtos", "Id", cascadeDelete: true);
            DropColumn("dbo.Produtos", "CompraItem_Id");
            DropColumn("dbo.CompraItens", "Preco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompraItens", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produtos", "CompraItem_Id", c => c.Int());
            DropForeignKey("dbo.CompraItens", "ProdutoID", "dbo.Produtos");
            DropIndex("dbo.CompraItens", new[] { "ProdutoID" });
            DropColumn("dbo.CompraItens", "ProdutoID");
            DropColumn("dbo.CompraItens", "PrecoUnitario");
            CreateIndex("dbo.Produtos", "CompraItem_Id");
            AddForeignKey("dbo.Produtos", "CompraItem_Id", "dbo.CompraItens", "Id");
        }
    }
}
