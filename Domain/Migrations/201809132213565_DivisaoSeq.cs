namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DivisaoSeq : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ExercicioTreino");
            AddColumn("dbo.ExercicioTreino", "DivisaoId", c => c.Int(nullable: false));
            AddColumn("dbo.ExercicioTreino", "DivisaoSeq", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ExercicioTreino", new[] { "DivisaoId", "DivisaoSeq", "Sequencia" });
            DropColumn("dbo.ExercicioTreino", "Treino");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExercicioTreino", "Treino", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.ExercicioTreino");
            DropColumn("dbo.ExercicioTreino", "DivisaoSeq");
            DropColumn("dbo.ExercicioTreino", "DivisaoId");
            AddPrimaryKey("dbo.ExercicioTreino", new[] { "Treino", "Sequencia" });
        }
    }
}
