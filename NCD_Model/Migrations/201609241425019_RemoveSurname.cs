namespace NCD_Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSurname : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CriminalPersons", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CriminalPersons", "Surname", c => c.String());
        }
    }
}
