namespace FitnessTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "UserId");
        }
    }
}
