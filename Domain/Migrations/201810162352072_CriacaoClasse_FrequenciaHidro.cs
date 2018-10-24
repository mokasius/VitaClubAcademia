namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoClasse_FrequenciaHidro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FrequenciaHidro",
                c => new
                    {
                        AlunoId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Selecionado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlunoId, t.Data });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FrequenciaHidro");
        }
    }
}
