namespace Chat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 4000),
                        LastName = c.String(nullable: false, maxLength: 4000),
                        Email = c.String(nullable: false, maxLength: 4000),
                        PassWord = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 4000),
                        DateTime = c.DateTime(nullable: false),
                        ChatUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChatUsers", t => t.ChatUserId, cascadeDelete: true)
                .Index(t => t.ChatUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ChatUserId", "dbo.ChatUsers");
            DropIndex("dbo.Messages", new[] { "ChatUserId" });
            DropTable("dbo.Messages");
            DropTable("dbo.ChatUsers");
        }
    }
}
