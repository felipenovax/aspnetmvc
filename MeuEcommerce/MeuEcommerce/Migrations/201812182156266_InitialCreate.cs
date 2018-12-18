namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Imagem = c.String(),
                        Descrição = c.String(),
                        IdCategoria = c.Int(nullable: false),
                        Fornecedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedors", t => t.Fornecedor_Id)
                .Index(t => t.Fornecedor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Fornecedor_Id", "dbo.Fornecedors");
            DropIndex("dbo.Produtoes", new[] { "Fornecedor_Id" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Fornecedors");
            DropTable("dbo.Categorias");
        }
    }
}
