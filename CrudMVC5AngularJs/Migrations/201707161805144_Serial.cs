namespace CrudMVC5AngularJs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Serial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contato", "Serial", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contato", "Serial");
        }
    }
}
