namespace OpenRelicsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConnectionsTemp",
                c => new
                    {
                        Ascendant = c.Int(nullable: false),
                        Descendant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ascendant, t.Descendant });
            
            CreateTable(
                "dbo.RelicsTemp",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        State = c.String(),
                        RegisterNumber = c.String(),
                        Dating = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        PlaceName = c.String(),
                        CommuneName = c.String(),
                        DistrictName = c.String(),
                        VoivodeshipName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RelicsTemp");
            DropTable("dbo.ConnectionsTemp");
        }
    }
}
