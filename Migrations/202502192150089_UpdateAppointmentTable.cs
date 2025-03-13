namespace AcunMedyaHospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppointmentTable : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Appointments", "PatientPhone", c => c.String());
            //AddColumn("dbo.Appointments", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "CreatedDate");
            DropColumn("dbo.Appointments", "PatientPhone");
        }
    }
}
