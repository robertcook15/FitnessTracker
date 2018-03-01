namespace FitnessTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBmiModelToAutoConvert : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BmiModels", "BmiResult");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BmiModels", "BmiResult", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
