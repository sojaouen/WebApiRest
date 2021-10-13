using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApiRest.Models;

namespace TP2WebAPIRest_.Controllers
{
    public class StagiairesController : ApiController
    {
        private StagiairesDBContext db = new StagiairesDBContext();
        // les actions de recherches, d'ajout, de suppression de modification ...
        // Action = Méthode

        // l'ajout un stagiaire --> envoyer un objet stagiaire POST

        [HttpPost]
        [Route("stagiaire/add")]
        public bool AjoutStagiaire(Stagiaire stagiaire)
        {
            db.Stagiaires.Add(stagiaire);
            int i = db.SaveChanges();

            return (i > 0);
        }

        // récupérer la liste des stagiaires à partir 
        // alors l'action est un Get
        [HttpGet]
        [Route("liste/all")]

        public List<Stagiaire> GetStagiaires()
        {
            return db.Stagiaires.ToList();
        }

        [HttpGet]
        [Route("liste/1")]
        public Stagiaire GetStagiaire1()
        //Exemple
        {
            Stagiaire stagiaireRecherche = db.Stagiaires.FirstOrDefault(x => x.Id == 1);
            return stagiaireRecherche;
        }

        // Suppression peut se faire avec Get/Delete

        [HttpDelete]
        [Route("stagiaire/supp/{id}")]

        public HttpStatusCode SuppStagiaire(int id)
        {
            try
            {

                //Stagiaire stagiaireASupp = db.Stagiaires.FirstOrDefault(x => x.Id == id);
                Stagiaire stagiaireASupp = db.Stagiaires.Find(id);
                if (stagiaireASupp == null) return HttpStatusCode.NotFound;
                db.Stagiaires.Remove(stagiaireASupp);
                db.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        // Modification

        [HttpPut]
        [Route("stagiaire/modif")]

        public HttpStatusCode ModifStagiaire(Stagiaire stagiaire)
        {
     
            Stagiaire stagiaireAModifier = db.Stagiaires.FirstOrDefault(x => x.Id == stagiaire.Id);
            stagiaireAModifier.Nom = stagiaire.Nom;
            stagiaireAModifier.Prenom = stagiaire.Prenom;

            db.SaveChanges();

            return HttpStatusCode.OK;

        }

        // Recherche par critere -> un bout a chercher dans le nom, le prenom, l'email, ...

        [HttpGet]
        [Route("stagiaire/search/{crit}")]

        public List<Stagiaire> RechercheParCritere(string crit)
        {
            var liste = db.Stagiaires.Where(x => x.Nom.Contains(crit) || x.Prenom.Contains(crit));

            return liste.ToList();
        }
    }
}