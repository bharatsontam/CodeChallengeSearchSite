namespace SearchSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SearchId = c.Guid(nullable: false),
                        Adults = c.Int(nullable: false),
                        Children = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SearchDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Location = c.String(),
                        CheckIn = c.DateTime(),
                        CheckOut = c.DateTime(),
                        RoomsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SearchDetails");
            DropTable("dbo.Rooms");
        }
    }
}
