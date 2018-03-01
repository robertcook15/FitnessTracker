namespace FitnessTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdForBmi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BmiModels", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BmiModels", "UserId");
        }
    }
}
