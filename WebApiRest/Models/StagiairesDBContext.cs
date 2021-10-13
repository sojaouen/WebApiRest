using System;
using System.Data.Entity;
using System.Linq;

namespace WebApiRest.Models
{
    public class StagiairesDBContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « StagiairesDBContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « WebApiRest.Models.StagiairesDBContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « StagiairesDBContext » dans le fichier de configuration de l'application.
        public StagiairesDBContext()
            : base("name=StagiairesDBContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Stagiaire> Stagiaires { get; set; }

        public virtual DbSet<Module> Modules { get; set; } // On ajoute une table --> Migration
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}