namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovoAlunosTreinos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlunosTreinos", "AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.AlunosTreinos", "TreinoId", "dbo.Treino");
            DropIndex("dbo.AlunosTreinos", new[] { "AlunoId" });
            DropIndex("dbo.AlunosTreinos", new[] { "TreinoId" });
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
            
            DropColumn("dbo.Treino", "DataInicial");
            DropColumn("dbo.Treino", "DataFinal");
            DropColumn("dbo.Treino", "Status");
            DropTable("dbo.AlunosTreinos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AlunosTreinos",
                c => new
                    {
                        AlunoId = c.Int(nullable: false),
                        TreinoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlunoId, t.TreinoId });
            
            AddColumn("dbo.Treino", "Status", c => c.Int());
            AddColumn("dbo.Treino", "DataFinal", c => c.DateTime());
            AddColumn("dbo.Treino", "DataInicial", c => c.DateTime());
            DropTable("dbo.AlunosTreinos");
            CreateIndex("dbo.AlunosTreinos", "TreinoId");
            CreateIndex("dbo.AlunosTreinos", "AlunoId");
            AddForeignKey("dbo.AlunosTreinos", "TreinoId", "dbo.Treino", "Id");
            AddForeignKey("dbo.AlunosTreinos", "AlunoId", "dbo.Aluno", "Id");
        }
    }
}
