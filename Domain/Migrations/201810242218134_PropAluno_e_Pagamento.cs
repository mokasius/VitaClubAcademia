namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropAluno_e_Pagamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Excluido", c => c.Int(nullable: false));
            AddColumn("dbo.Pagamento", "DataPagamento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagamento", "DataPagamento");
            DropColumn("dbo.Aluno", "Excluido");
        }
    }
}
