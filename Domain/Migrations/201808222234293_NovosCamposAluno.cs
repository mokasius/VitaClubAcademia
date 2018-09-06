namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovosCamposAluno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Telefone", c => c.String());
            AddColumn("dbo.Aluno", "Objetivo", c => c.String());
            AddColumn("dbo.Aluno", "Sexo", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "Sexo");
            DropColumn("dbo.Aluno", "Objetivo");
            DropColumn("dbo.Aluno", "Telefone");
        }
    }
}
