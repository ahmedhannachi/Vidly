namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresAndMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id,Name,SignUpFee,DurationInMonths,DiscountRate) VALUES(1,'Pay as you go',0,0,0),(2,'Monthly',10,1,10),(3,'Quarterly',20,3,20),(4,'Annually',30,12,30)");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy'),('Action'),('Romance'),('Family')");
        }
        
        public override void Down()
        {
        }
    }
}
