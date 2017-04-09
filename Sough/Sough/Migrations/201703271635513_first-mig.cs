namespace Sough.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Voitures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        marque = c.String(nullable: false, maxLength: 50),
                        Modele = c.String(nullable: false, maxLength: 30),
                        kilometrage = c.Long(nullable: false),
                        carburant = c.String(nullable: false, maxLength: 20),
                        BoiteDeVitesse = c.String(nullable: false, maxLength: 30),
                        color = c.String(maxLength: 30),
                        car_shape = c.String(maxLength: 30),
                        EstNeuf = c.String(nullable: false, maxLength: 15),
                        trader_name = c.String(maxLength: 50),
                        email = c.String(),
                        trader_facebook = c.String(),
                        trader_instagram = c.String(),
                        phone = c.String(nullable: false, maxLength: 13),
                        ville = c.String(nullable: false, maxLength: 50),
                        prix = c.Long(nullable: false),
                        temps = c.DateTime(nullable: false),
                        image1 = c.Binary(),
                        image2 = c.Binary(),
                        image3 = c.Binary(),
                        image4 = c.Binary(),
                        img_count = c.Int(nullable: false),
                        password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Voitures");
        }
    }
}
