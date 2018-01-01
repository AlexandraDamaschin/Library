namespace Library.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ISBN = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Loan",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        DateJoined = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loan", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Loan", "BookId", "dbo.Book");
            DropIndex("dbo.Loan", new[] { "BookId" });
            DropIndex("dbo.Loan", new[] { "MemberId" });
            DropTable("dbo.Member");
            DropTable("dbo.Loan");
            DropTable("dbo.Book");
        }
    }
}
