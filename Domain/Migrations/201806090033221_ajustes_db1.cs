namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustes_db1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(),
                        Idade = c.Int(),
                        Profissao = c.String(),
                        FrequenciaSemanal = c.Int(),
                        Peso = c.Double(),
                        Altura = c.Double(),
                        Email = c.String(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Treino",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        DataInicial = c.DateTime(),
                        DataFinal = c.DateTime(),
                        Status = c.Int(),
                        AlunoId = c.Int(),
                        AlunoDO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aluno", t => t.AlunoId)
                .ForeignKey("dbo.Aluno", t => t.AlunoDO_Id)
                .Index(t => t.AlunoId)
                .Index(t => t.AlunoDO_Id);
            
            CreateTable(
                "dbo.DivisaoTreino",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TreinoId = c.Int(),
                        Sequencia = c.Int(),
                        Descricao = c.String(),
                        TreinoDO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Treino", t => t.TreinoId)
                .ForeignKey("dbo.Treino", t => t.TreinoDO_Id)
                .Index(t => t.TreinoId)
                .Index(t => t.TreinoDO_Id);
            
            CreateTable(
                "dbo.Exercicio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Serie = c.Int(),
                        Repeticoes = c.Int(),
                        Descanso = c.Int(),
                        Carga = c.Int(),
                        GrupoMuscular = c.Int(),
                        DivisaoTreinoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Frequencia",
                c => new
                    {
                        AlunoId = c.Int(nullable: false),
                        Sequencia = c.Int(nullable: false),
                        DataPresenca = c.DateTime(),
                        TreinoId = c.Int(nullable: false),
                        SequenciaDivisao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlunoId, t.Sequencia })
                .ForeignKey("dbo.Aluno", t => t.AlunoId)
                .Index(t => t.AlunoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Frequencia", "AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.Treino", "AlunoDO_Id", "dbo.Aluno");
            DropForeignKey("dbo.DivisaoTreino", "TreinoDO_Id", "dbo.Treino");
            DropForeignKey("dbo.DivisaoTreino", "TreinoId", "dbo.Treino");
            DropForeignKey("dbo.Treino", "AlunoId", "dbo.Aluno");
            DropIndex("dbo.Frequencia", new[] { "AlunoId" });
            DropIndex("dbo.DivisaoTreino", new[] { "TreinoDO_Id" });
            DropIndex("dbo.DivisaoTreino", new[] { "TreinoId" });
            DropIndex("dbo.Treino", new[] { "AlunoDO_Id" });
            DropIndex("dbo.Treino", new[] { "AlunoId" });
            DropTable("dbo.Frequencia");
            DropTable("dbo.Exercicio");
            DropTable("dbo.DivisaoTreino");
            DropTable("dbo.Treino");
            DropTable("dbo.Aluno");
        }
    }
}
