namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3fd8cb5e-fed4-4259-aff7-9338cf1d286b', N'admin@vidly.com', 0, N'AJ9TJtNRMaKEdzNS8VFV6+xqb1XVMP9e3VXkqHoMnCw++yGCySqVqs1WxZ2nXJBF3Q==', N'4a654fd5-13b7-4dc7-b1a8-aa3153fc40c4', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69c22f33-6800-4cdd-a80a-ff4e3a4a7396', N'guest@vidly.com', 0, N'AN90JeQOWzozmzB0GQPEU3yjaN9vyUvx4QgC/X8D7CIcpcvjqv411077pf4ldBu8Xw==', N'c8591c97-b1d2-4f05-ac5d-87474eba578f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2bcb77fd-16e2-433c-8cc6-252d7f99a527', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3fd8cb5e-fed4-4259-aff7-9338cf1d286b', N'2bcb77fd-16e2-433c-8cc6-252d7f99a527')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
