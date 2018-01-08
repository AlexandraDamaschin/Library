namespace Library.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loan", "LoanDate", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loan", "LoanDate");
        }
    }
}
