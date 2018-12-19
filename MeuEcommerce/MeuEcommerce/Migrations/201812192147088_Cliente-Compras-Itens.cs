namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteComprasItens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.CompraItens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qtd = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Compra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compras", t => t.Compra_Id)
                .Index(t => t.Compra_Id);
            
            AddColumn("dbo.Produtos", "CompraItem_Id", c => c.Int());
            CreateIndex("dbo.Produtos", "CompraItem_Id");
            AddForeignKey("dbo.Produtos", "CompraItem_Id", "dbo.CompraItens", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.CompraItens", "Compra_Id", "dbo.Compras");
            DropForeignKey("dbo.Produtos", "CompraItem_Id", "dbo.CompraItens");
            DropIndex("dbo.CompraItens", new[] { "Compra_Id" });
            DropIndex("dbo.Compras", new[] { "Cliente_Id" });
            DropIndex("dbo.Produtos", new[] { "CompraItem_Id" });
            DropColumn("dbo.Produtos", "CompraItem_Id");
            DropTable("dbo.CompraItens");
            DropTable("dbo.Compras");
            DropTable("dbo.Clientes");
        }
    }
}
