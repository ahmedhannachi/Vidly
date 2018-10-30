namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberRentedToRentalModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberRented", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberRented");
        }
    }
}
