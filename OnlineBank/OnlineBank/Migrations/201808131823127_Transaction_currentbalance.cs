namespace OnlineBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaction_currentbalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "CurrentBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "CurrentBalance");
        }
    }
}
