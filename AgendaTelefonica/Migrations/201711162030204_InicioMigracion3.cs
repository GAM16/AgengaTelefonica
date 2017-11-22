namespace AgendaTelefonica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicioMigracion3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Telefonos", "Numero", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Telefonos", "Numero", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
