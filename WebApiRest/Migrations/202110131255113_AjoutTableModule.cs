namespace WebApiRest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutTableModule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Modules");
        }
    }
}
