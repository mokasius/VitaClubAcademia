namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlunosTreinos3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlunosTreinos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        TreinoId = c.Int(nullable: false),
                        Descricao = c.String(),
                        DataInicial = c.DateTime(),
                        DataFinal = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlunosTreinos");
        }
    }
}
