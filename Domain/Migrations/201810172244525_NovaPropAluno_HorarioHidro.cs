namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovaPropAluno_HorarioHidro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "HorarioHidro", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "HorarioHidro");
        }
    }
}
