using System.Data.Entity;

namespace Sough.Models
{
    public class ToujjarDatabase : DbContext
    {
        // Vous pouvez ajouter du code personnalisé à ce fichier. Les modifications ne seront pas remplacées.
        // 
        // Si vous voulez qu’Entity Framework abandonne et régénère la base de données
        // automatiquement à chaque fois que vous modifiez le schéma du modèle, ajoutez le code
        // suivant à la méthode Application_Start dans le fichier Global.asax.
        // Remarque : cette opération supprime et recrée la base de données à chaque modification du modèle.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Sough.Models.ToujjarDatabase>());

        public ToujjarDatabase() : base("name=ToujjarDatabase")
        {
        }

        public DbSet<Voiture> Voitures { get; set; }

        public DbSet<Vetement> Vetements { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<DeleteInfo> DeleteInfoes { get; set; }
    }
}
