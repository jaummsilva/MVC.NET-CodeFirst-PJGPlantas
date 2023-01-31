namespace PJGPlantasMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boletoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.String(),
                        Rg = c.String(),
                        Endereco = c.String(),
                        Complemento = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        BoletoId = c.Int(),
                        PixId = c.Int(),
                        CartaoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boletoes", t => t.BoletoId)
                .ForeignKey("dbo.Cartaos", t => t.CartaoId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Pixes", t => t.PixId)
                .Index(t => t.UsuarioId)
                .Index(t => t.BoletoId)
                .Index(t => t.PixId)
                .Index(t => t.CartaoId);
            
            CreateTable(
                "dbo.Cartaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeTitular = c.String(nullable: false, maxLength: 200),
                        Validade = c.String(nullable: false, maxLength: 5),
                        CVV = c.String(nullable: false, maxLength: 3),
                        Numero = c.String(nullable: false, maxLength: 19),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Cpf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        PlantaId = c.Int(nullable: false),
                        Dth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plantas", t => t.PlantaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.PlantaId);
            
            CreateTable(
                "dbo.Plantas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Double(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompraId = c.Int(nullable: false),
                        PlantaId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Dth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compras", t => t.CompraId, cascadeDelete: true)
                .ForeignKey("dbo.Plantas", t => t.PlantaId, cascadeDelete: true)
                .Index(t => t.CompraId)
                .Index(t => t.PlantaId);
            
            CreateTable(
                "dbo.Pixes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(),
                        Email = c.String(),
                        Banco = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "PixId", "dbo.Pixes");
            DropForeignKey("dbo.Compras", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Comentarios", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ItemCompras", "PlantaId", "dbo.Plantas");
            DropForeignKey("dbo.ItemCompras", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.Comentarios", "PlantaId", "dbo.Plantas");
            DropForeignKey("dbo.Cartaos", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Compras", "CartaoId", "dbo.Cartaos");
            DropForeignKey("dbo.Compras", "BoletoId", "dbo.Boletoes");
            DropIndex("dbo.ItemCompras", new[] { "PlantaId" });
            DropIndex("dbo.ItemCompras", new[] { "CompraId" });
            DropIndex("dbo.Comentarios", new[] { "PlantaId" });
            DropIndex("dbo.Comentarios", new[] { "UsuarioId" });
            DropIndex("dbo.Cartaos", new[] { "UsuarioID" });
            DropIndex("dbo.Compras", new[] { "CartaoId" });
            DropIndex("dbo.Compras", new[] { "PixId" });
            DropIndex("dbo.Compras", new[] { "BoletoId" });
            DropIndex("dbo.Compras", new[] { "UsuarioId" });
            DropTable("dbo.Pixes");
            DropTable("dbo.ItemCompras");
            DropTable("dbo.Plantas");
            DropTable("dbo.Comentarios");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Cartaos");
            DropTable("dbo.Compras");
            DropTable("dbo.Boletoes");
        }
    }
}
