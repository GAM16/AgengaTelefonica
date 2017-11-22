namespace AgendaTelefonica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicioMigracion1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TelefonoPersonas", new[] { "Persona_Id", "Persona_Cedula" }, "dbo.Personas");
            DropIndex("dbo.TelefonoPersonas", new[] { "Persona_Id", "Persona_Cedula" });
            DropPrimaryKey("dbo.Personas");
            DropPrimaryKey("dbo.TelefonoPersonas");
            AddPrimaryKey("dbo.Personas", "Id");
            AddPrimaryKey("dbo.TelefonoPersonas", new[] { "Telefono_Id", "Persona_Id" });
            CreateIndex("dbo.TelefonoPersonas", "Persona_Id");
            AddForeignKey("dbo.TelefonoPersonas", "Persona_Id", "dbo.Personas", "Id", cascadeDelete: true);
            DropColumn("dbo.TelefonoPersonas", "Persona_Cedula");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TelefonoPersonas", "Persona_Cedula", c => c.String(nullable: false, maxLength: 11));
            DropForeignKey("dbo.TelefonoPersonas", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.TelefonoPersonas", new[] { "Persona_Id" });
            DropPrimaryKey("dbo.TelefonoPersonas");
            DropPrimaryKey("dbo.Personas");
            AddPrimaryKey("dbo.TelefonoPersonas", new[] { "Telefono_Id", "Persona_Id", "Persona_Cedula" });
            AddPrimaryKey("dbo.Personas", new[] { "Id", "Cedula" });
            CreateIndex("dbo.TelefonoPersonas", new[] { "Persona_Id", "Persona_Cedula" });
            AddForeignKey("dbo.TelefonoPersonas", new[] { "Persona_Id", "Persona_Cedula" }, "dbo.Personas", new[] { "Id", "Cedula" }, cascadeDelete: true);
        }
    }
}
