namespace AgendaTelefonica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicioMigracion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telefonos", new[] { "Persona_Id", "Persona_Cedula" }, "dbo.Personas");
            DropIndex("dbo.Telefonos", new[] { "Persona_Id", "Persona_Cedula" });
            CreateTable(
                "dbo.TelefonoPersonas",
                c => new
                    {
                        Telefono_Id = c.Int(nullable: false),
                        Persona_Id = c.Int(nullable: false),
                        Persona_Cedula = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => new { t.Telefono_Id, t.Persona_Id, t.Persona_Cedula })
                .ForeignKey("dbo.Telefonos", t => t.Telefono_Id, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => new { t.Persona_Id, t.Persona_Cedula }, cascadeDelete: true)
                .Index(t => t.Telefono_Id)
                .Index(t => new { t.Persona_Id, t.Persona_Cedula });
            
            DropColumn("dbo.Telefonos", "Persona_Id");
            DropColumn("dbo.Telefonos", "Persona_Cedula");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Telefonos", "Persona_Cedula", c => c.String(maxLength: 11));
            AddColumn("dbo.Telefonos", "Persona_Id", c => c.Int());
            DropForeignKey("dbo.TelefonoPersonas", new[] { "Persona_Id", "Persona_Cedula" }, "dbo.Personas");
            DropForeignKey("dbo.TelefonoPersonas", "Telefono_Id", "dbo.Telefonos");
            DropIndex("dbo.TelefonoPersonas", new[] { "Persona_Id", "Persona_Cedula" });
            DropIndex("dbo.TelefonoPersonas", new[] { "Telefono_Id" });
            DropTable("dbo.TelefonoPersonas");
            CreateIndex("dbo.Telefonos", new[] { "Persona_Id", "Persona_Cedula" });
            AddForeignKey("dbo.Telefonos", new[] { "Persona_Id", "Persona_Cedula" }, "dbo.Personas", new[] { "Id", "Cedula" });
        }
    }
}
