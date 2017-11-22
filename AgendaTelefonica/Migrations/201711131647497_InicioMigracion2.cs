namespace AgendaTelefonica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicioMigracion2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TelefonoPersonas", "Telefono_Id", "dbo.Telefonos");
            DropForeignKey("dbo.TelefonoPersonas", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.TelefonoPersonas", new[] { "Telefono_Id" });
            DropIndex("dbo.TelefonoPersonas", new[] { "Persona_Id" });
            AddColumn("dbo.Telefonos", "Cedula", c => c.String());
            AddColumn("dbo.Telefonos", "Persona_Id", c => c.Int());
            CreateIndex("dbo.Telefonos", "Persona_Id");
            AddForeignKey("dbo.Telefonos", "Persona_Id", "dbo.Personas", "Id");
            DropTable("dbo.TelefonoPersonas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TelefonoPersonas",
                c => new
                    {
                        Telefono_Id = c.Int(nullable: false),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Telefono_Id, t.Persona_Id });
            
            DropForeignKey("dbo.Telefonos", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.Telefonos", new[] { "Persona_Id" });
            DropColumn("dbo.Telefonos", "Persona_Id");
            DropColumn("dbo.Telefonos", "Cedula");
            CreateIndex("dbo.TelefonoPersonas", "Persona_Id");
            CreateIndex("dbo.TelefonoPersonas", "Telefono_Id");
            AddForeignKey("dbo.TelefonoPersonas", "Persona_Id", "dbo.Personas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TelefonoPersonas", "Telefono_Id", "dbo.Telefonos", "Id", cascadeDelete: true);
        }
    }
}
