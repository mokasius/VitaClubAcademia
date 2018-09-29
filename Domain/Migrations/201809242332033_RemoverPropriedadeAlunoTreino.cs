namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverPropriedadeAlunoTreino : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AlunosTreinos", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlunosTreinos", "Descricao", c => c.String());
        }
    }
}
