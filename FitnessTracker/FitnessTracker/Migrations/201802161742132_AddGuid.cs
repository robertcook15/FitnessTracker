namespace FitnessTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "UserId");
        }
    }
}
