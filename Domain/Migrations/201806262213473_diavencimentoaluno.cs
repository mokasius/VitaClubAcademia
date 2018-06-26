namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diavencimentoaluno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "DiaVencimento", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "DiaVencimento");
        }
    }
}
