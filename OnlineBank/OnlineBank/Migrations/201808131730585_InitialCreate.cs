namespace OnlineBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        DateOpened = c.DateTime(),
                        DateClosed = c.DateTime(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        DOB = c.DateTime(nullable: false),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.String(),
                        TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartingBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Account_AccountID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountID)
                .Index(t => t.Account_AccountID);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanID = c.Int(nullable: false, identity: true),
                        DateOpened = c.DateTime(),
                        DateClosed = c.DateTime(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.LoanID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "Account_AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Loans", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Transactions", new[] { "Account_AccountID" });
            DropIndex("dbo.Accounts", new[] { "Customer_CustomerID" });
            DropTable("dbo.Loans");
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
