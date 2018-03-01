namespace FitnessTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBmiResultToBmiTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BmiModels", "BmiResult", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BmiModels", "BmiResult");
        }
    }
}
