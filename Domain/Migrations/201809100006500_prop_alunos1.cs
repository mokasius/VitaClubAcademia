namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prop_alunos1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Turno", c => c.Int());
            AddColumn("dbo.Aluno", "DiasSemana", c => c.String());
            AddColumn("dbo.Aluno", "Tipo", c => c.Int());
            AddColumn("dbo.Aluno", "Observacao", c => c.String());
            AddColumn("dbo.Aluno", "PlanoSaude", c => c.String());
            AddColumn("dbo.Aluno", "TipoSanguineo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "TipoSanguineo");
            DropColumn("dbo.Aluno", "PlanoSaude");
            DropColumn("dbo.Aluno", "Observacao");
            DropColumn("dbo.Aluno", "Tipo");
            DropColumn("dbo.Aluno", "DiasSemana");
            DropColumn("dbo.Aluno", "Turno");
        }
    }
}
