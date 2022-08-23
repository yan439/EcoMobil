// Houda, Yannick

using EcoMobil.Models.BDD;
using EcoMobil.Models.ManagementService;

namespace EcoMobil.Models.Services
{
    public class DalSecretariat
    {
        private BddContext _bddContext;

        public DalSecretariat()
        {
            _bddContext = new BddContext();
        }

        //public void ListService()
        //{
        //    using BddContext ctx = new BddContext();
        //    var query = from utilisateurs in ctx.Utilisateurs
        //                join services in ctx.Services on utilisateurs.ServiceId equals services.Id
        //                join vehicules in ctx.Vehicules on services.VehiculeId equals vehicules.Id
        //                join justificatifs in ctx.Justificatifs on vehicules.JustificatifId equals justificatifs.Id
        //                select new
        //                {
        //                    services.TypeService,
        //                    utilisateurs.Nom,
        //                    utilisateurs.Prenom,
        //                    justificatifs.PermisDeConduire,
        //                    justificatifs.CertificatDImmatriculation,
        //                    justificatifs.Assurance,
        //                    justificatifs.ControleTechnique
        //                };

        //    var res = query.ToList();
        //}

        public void ValiderCovoiturage(int Id)
        {
            Covoiturage covoiturage = _bddContext.Covoiturages.Find(Id);

            if (covoiturage != null)
            {
                covoiturage.Etat = "Publié";

                _bddContext.SaveChanges();
            }
        }

        public void RejeterCovoiturage(int Id)
        {
            Covoiturage covoiturage = _bddContext.Covoiturages.Find(Id);

            if (covoiturage != null)
            {
                covoiturage.Etat = "Rejeté";

                _bddContext.SaveChanges();
            }
        }
        //********************************* Gestion des prpositions des locations *********/
        public void ValiderLocation(int Id)
        {
            Location location = _bddContext.Locations.Find(Id);

            if (location != null)
            {
                location.Etat = "Publié";

                _bddContext.SaveChanges();
            }
        }
        public void RejeterLocation(int Id)
        {
            Location location = _bddContext.Locations.Find(Id);

            if (location != null)
            {
                location.Etat = "Rejeté";

                _bddContext.SaveChanges();
            }
        }

        //********************************* Gestion des prpositions de livraison des colis *********/
        public void ValiderColis(int Id)
        {
            Colis colis = _bddContext.LesColis.Find(Id);

            if (colis != null)
            {
                colis.Etat = "Publié";

                _bddContext.SaveChanges();
            }
        }
        public void RejeterColis(int Id)
        {
            Colis colis = _bddContext.LesColis.Find(Id);

            if (colis != null)
            {
                colis.Etat = "Rejeté";

                _bddContext.SaveChanges();
            }
        }
    }
}