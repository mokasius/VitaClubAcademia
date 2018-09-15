namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Treino", "AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.DivisaoTreino", "TreinoId", "dbo.Treino");
            DropForeignKey("dbo.DivisaoTreino", "TreinoDO_Id", "dbo.Treino");
            DropIndex("dbo.Treino", new[] { "AlunoId" });
            DropIndex("dbo.DivisaoTreino", new[] { "TreinoId" });
            DropIndex("dbo.DivisaoTreino", new[] { "TreinoDO_Id" });
            AddColumn("dbo.Treino", "Observacao", c => c.String());
            AddColumn("dbo.DivisaoTreino", "Nome", c => c.String());
            DropColumn("dbo.Treino", "AlunoId");
            DropColumn("dbo.DivisaoTreino", "TreinoDO_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DivisaoTreino", "TreinoDO_Id", c => c.Int());
            AddColumn("dbo.Treino", "AlunoId", c => c.Int());
            DropColumn("dbo.DivisaoTreino", "Nome");
            DropColumn("dbo.Treino", "Observacao");
            CreateIndex("dbo.DivisaoTreino", "TreinoDO_Id");
            CreateIndex("dbo.DivisaoTreino", "TreinoId");
            CreateIndex("dbo.Treino", "AlunoId");
            AddForeignKey("dbo.DivisaoTreino", "TreinoDO_Id", "dbo.Treino", "Id");
            AddForeignKey("dbo.DivisaoTreino", "TreinoId", "dbo.Treino", "Id");
            AddForeignKey("dbo.Treino", "AlunoId", "dbo.Aluno", "Id");
        }
    }
}
