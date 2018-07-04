namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exercicioTreino : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExercicioTreino",
                c => new
                    {
                        Treino = c.Int(nullable: false),
                        Sequencia = c.Int(nullable: false),
                        Serie = c.Int(),
                        Repeticoes = c.Int(),
                        Descanso = c.Int(),
                        Carga = c.Int(),
                        ExercicioId = c.Int(),
                    })
                .PrimaryKey(t => new { t.Treino, t.Sequencia });
            
            DropColumn("dbo.Exercicio", "Serie");
            DropColumn("dbo.Exercicio", "Repeticoes");
            DropColumn("dbo.Exercicio", "Descanso");
            DropColumn("dbo.Exercicio", "Carga");
            DropColumn("dbo.Exercicio", "DivisaoTreinoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercicio", "DivisaoTreinoId", c => c.Int());
            AddColumn("dbo.Exercicio", "Carga", c => c.Int());
            AddColumn("dbo.Exercicio", "Descanso", c => c.Int());
            AddColumn("dbo.Exercicio", "Repeticoes", c => c.Int());
            AddColumn("dbo.Exercicio", "Serie", c => c.Int());
            DropTable("dbo.ExercicioTreino");
        }
    }
}
