namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaPagamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AlunoId = c.Int(nullable: false),
                        Mes = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.AlunoId, t.Mes, t.Ano });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pagamento");
        }
    }
}
