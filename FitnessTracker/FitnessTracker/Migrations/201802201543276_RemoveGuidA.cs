namespace FitnessTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGuidA : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Workouts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "UserId", c => c.Guid(nullable: false));
        }
    }
}
