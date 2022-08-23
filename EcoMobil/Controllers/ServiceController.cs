// Houda, Yannick, Hamid

using EcoMobil.Models.BDD;
using EcoMobil.Models.ManagementService;
using EcoMobil.Models.Personne;
using EcoMobil.Models.Services;
using EcoMobil.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using XAct.Users;

namespace EcoMobil.Controllers
{
    public class ServiceController : Controller
    {
        private DalService dalService;

        private DalUtilisateur dalUtilisateur;


        private DalReservation dalReservation;


        public ServiceController()
        {
            dalService = new DalService();
            dalUtilisateur = new DalUtilisateur();
            dalReservation = new DalReservation();
        }
       


        //***************************** choix de service *************************//
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
                return Redirect("/Connexion/IndexConnexion");

                
        }


        [HttpPost]
        public ActionResult Index(Service service)
        {
            var valeurChoisie = service.TypeService;

            service.Id = dalService.LireTypeService(valeurChoisie);

            if (service.Id == 1)
            {
                return RedirectToAction("CreerCovoiturage");
            }
            else if (service.Id == 2)
            {

                return RedirectToAction("CreerLocation");
            }
            else if (service.Id == 3)
            {

                return RedirectToAction("AjouterUnColis");
            }

            return View();
        }

        //////****************************************************Covoiturage*******************************************************//



        //********************Liste  Pour contributeur*********************//

        public IActionResult ListeCovoiturageContributeur()
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            SecretariatViewModel svm = new SecretariatViewModel

            {
                Locations =  dalService.ObtientTousLesLocations().ToList(),
                LocationsContributeur = dalService.ObtientTousLesLocations().Where(l => l.UtilisateurId == UtilisateurId).ToList(),
                LesColis = dalService.ObtientTousLesColis().ToList(),
                ColisContributeur = dalService.ObtientTousLesColis().Where(c => c.UtilisateurId == UtilisateurId).ToList(),
                Covoiturages = dalService.ObtientTousLesCovoiturages().ToList(),
                CovoituragesContributeur = dalService.ObtientTousLesCovoiturages().Where(c => c.UtilisateurId == UtilisateurId).ToList(),
                ReservationsConsommateurs = dalReservation.ObtenirToutesLesReservations().ToList(),
                ReservationsContributeur = dalReservation.ObtenirToutesLesReservations().Where(r => r.UtilisateurId == UtilisateurId).ToList()
            };

            return View(svm);
        }



        //********************Recherche*********************//
        public ActionResult IndexCovoiturage(string lieu_depart, string lieu_arrivee, DateTime date_depart)
        {
            List<Covoiturage> listeDesCovoiturages = dalService.ObtientTousLesCovoiturages();
            if (lieu_depart != null)
            {
                return View(listeDesCovoiturages.Where(c => c.LieuDeDepart.Contains(lieu_depart)).ToList());
            }

            if (lieu_arrivee != null)
            {
                return View(listeDesCovoiturages.Where(c => c.LieuDArrivee.Contains(lieu_arrivee)).ToList());
            }

            if (date_depart.Year != 1)
            {
                return View(listeDesCovoiturages.Where(c => c.DateDeDepart == date_depart).ToList());
            }
            return View(listeDesCovoiturages);
        }


        //Crrer Covoiturage ===> association avec véhicule
          public IActionResult CreerCovoiturage() {
            
                return View();
        }

        [HttpPost]
        public ActionResult CreerCovoiturage(Covoiturage covoiturage)
        {
            
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

          

            int VehiculeId = dalService.AjouterVehicule( covoiturage.Vehicule.Modele, covoiturage.Vehicule.Automatique, covoiturage.Vehicule.Marque, covoiturage.Vehicule.Electrique, covoiturage.Vehicule.nombreDePortes, covoiturage.Vehicule.ControleTechnique );

            covoiturage.Etat = "En attente";
            dalService.AjouterCovoiturage(covoiturage.PlaceDisponible, covoiturage.LieuDeDepart, covoiturage.DateDeDepart, covoiturage.HeureDeDepart, covoiturage.LieuDArrivee, covoiturage.HeureDArrivee, covoiturage.Prix, covoiturage.Description, 1, VehiculeId, UtilisateurId, covoiturage.Etat);


            return Redirect("/Service/ListeCovoiturageContributeur"); 
        }




        //////************ModifierCovoiturage******************************//



        public IActionResult ModifierCovoiturage(int? id)
        {
            if (id.HasValue)
            {
                Covoiturage covoiturage = dalService.ObtientTousLesCovoiturages().FirstOrDefault(r => r.Id == id.Value);
                if (covoiturage == null)
                    return View("Error");
                          
                return View(covoiturage);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult ModifierCovoiturage(Covoiturage covoiturage)
        {

            dalService.ModifierVehicule(covoiturage.VehiculeId, covoiturage.Vehicule.Modele, covoiturage.Vehicule.Marque, covoiturage.Vehicule.Automatique, covoiturage.Vehicule.Electrique, covoiturage.Vehicule.nombreDePortes, covoiturage.Vehicule.ControleTechnique);

            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            dalService.ModifierCovoiturage(covoiturage.Id, covoiturage.PlaceDisponible, covoiturage.LieuDeDepart, covoiturage.DateDeDepart, covoiturage.HeureDeDepart, covoiturage.LieuDArrivee,  covoiturage.HeureDArrivee,  covoiturage.Prix, covoiturage.Description,covoiturage.Etat, 1, covoiturage.VehiculeId, UtilisateurId);

            return RedirectToAction("ListeCovoiturageContributeur");
        }



        //////************Supprimer    Covoiturage******************************//
        public ActionResult SupprimerCovoiturage(int id)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            dalService.SupprimerVehicule(id);
            dalService.SupprimerCovoiturage(id);

            return Redirect("/Home/Index");
        }


        //******************************************************Location***********************************************//

        //************** Reservation covoiturage**********//

        public ActionResult ReserverCovoiturage(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                dalReservation.AjouterReservation(DateTime.Now.ToShortDateString(), "En attente de validation", UtilisateurId, id);

                Covoiturage covoiturage = dalService.ObtenirCovoiturage(id);
                covoiturage.PlaceDisponible -= 1;
                dalService.ModifierCovoiturage(covoiturage);

                return View("IndexCovoiturage", dalService.ObtientTousLesCovoiturages());
            }
            else
                return Redirect("/Connexion/IndexConnexion");
  
        }




        //********************creer Location*********************//



        //Creer location += véhicule
        public IActionResult CreerLocation()
        {
            return View();
        }

        public ActionResult IndexLocation(double PrixParJour, string LieuDeDepot, DateTime Disponible)
        {
            List<Location> listeDesLocations = dalService.ObtientTousLesLocations();
            if (LieuDeDepot != null)
            {
                return View(listeDesLocations.Where(l => l.LieuDeDepot.Contains(LieuDeDepot)).ToList());
            }

            if (PrixParJour != 0.0)
            {
                return View(listeDesLocations.Where(l => l.PrixParJour<=(PrixParJour)).ToList());
            }

            if (Disponible.Year != 1)
            {
                return View(listeDesLocations.Where(l => l.Disponible == Disponible).ToList());
            }
            return View(listeDesLocations);
        }

        [HttpPost]
        public ActionResult CreerLocation(Location location)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            location.VehiculeId = dalService.AjouterVehicule(location.Vehicule.Modele, location.Vehicule.Electrique, location.Vehicule.Marque, location.Vehicule.Automatique, location.Vehicule.nombreDePortes, location.Vehicule.ControleTechnique);

            location.Etat = "En attente";

            dalService.AjouterLocation(location.Disponible, location.LieuDeDepot, location.PrixParJour, location.Description, 2, location.VehiculeId, UtilisateurId, location.Etat);


            return Redirect("/Service/ListeCovoiturageContributeur");
        }
        public IActionResult ModifierLocation(int? id)
        {

            if (id.HasValue)
            {
                Location location = dalService.ObtientTousLesLocations().FirstOrDefault(r => r.Id == id.Value);
                if (location == null)
                    return View("Error");



                return View(location);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult ModifierLocation(Location location)
        {

            dalService.ModifierVehicule(location.VehiculeId, location.Vehicule.Modele, location.Vehicule.Marque, location.Vehicule.Automatique, location.Vehicule.Electrique, location.Vehicule.nombreDePortes, location.Vehicule.ControleTechnique);

            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            dalService.ModifierLocation(location.Id, location.Disponible, location.LieuDeDepot, location.PrixParJour, location.Description, 2, location.VehiculeId, UtilisateurId, location.Etat);

            return Redirect("/Service/ListeCovoiturageContributeur");
        }
        //*****************Supprimer Location ***********************************

        public ActionResult SupprimerLocation(int id)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            dalService.SupprimerLocation(id);
            dalService.SupprimerVehicule(id);
            return Redirect("/Home/Index");
        }






        //********************Gestion des réservations *********************//

        public ActionResult AccepterReservation(int id)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            dalReservation.AccepterReservation(id);
            
            SecretariatViewModel svm = new SecretariatViewModel
            {
                Locations = dalService.ObtientTousLesLocations().ToList(),
                LocationsContributeur = dalService.ObtientTousLesLocations().Where(l => l.UtilisateurId == UtilisateurId).ToList(),
                Covoiturages = dalService.ObtientTousLesCovoiturages().ToList(),
                CovoituragesContributeur = dalService.ObtientTousLesCovoiturages().Where(c => c.UtilisateurId == UtilisateurId).ToList(),
                ReservationsConsommateurs = dalReservation.ObtenirToutesLesReservations().ToList(),
                ReservationsContributeur = dalReservation.ObtenirToutesLesReservations().Where(r => r.UtilisateurId == UtilisateurId).ToList()
            };
            
            return View("ListeCovoiturageContributeur",svm);
        }

        public ActionResult RefuserReservation(int id)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Reservation reservation = dalReservation.ObtenirReservation(id);
            Covoiturage covoiturage = dalService.ObtenirCovoiturage(reservation.CovoiturageId);
            covoiturage.PlaceDisponible += 1;
            dalService.ModifierCovoiturage(covoiturage);

            dalReservation.RefuserReservation(id);

            SecretariatViewModel svm = new SecretariatViewModel
            {
                Covoiturages = dalService.ObtientTousLesCovoiturages().ToList(),
                CovoituragesContributeur = dalService.ObtientTousLesCovoiturages().Where(c => c.UtilisateurId == UtilisateurId).ToList(),
                ReservationsConsommateurs = dalReservation.ObtenirToutesLesReservations().ToList(),
                ReservationsContributeur = dalReservation.ObtenirToutesLesReservations().Where(r => r.UtilisateurId == UtilisateurId).ToList()
            };

            return View("ListeCovoiturageContributeur", svm);
        }


        //********************Gestion des réservations par le consommateur*********************//

        public ActionResult AnnulerReservation(int id)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Reservation reservation = dalReservation.ObtenirReservation(id);
            Covoiturage covoiturage = dalService.ObtenirCovoiturage(reservation.CovoiturageId);
            covoiturage.PlaceDisponible += 1;
            dalService.ModifierCovoiturage(covoiturage);

            dalReservation.SupprimerReservation(id);

            SecretariatViewModel svm = new SecretariatViewModel
            {
                Covoiturages = dalService.ObtientTousLesCovoiturages().ToList(),
                CovoituragesContributeur = dalService.ObtientTousLesCovoiturages().Where(c => c.UtilisateurId == UtilisateurId).ToList(),
                ReservationsConsommateurs = dalReservation.ObtenirToutesLesReservations().ToList(),
                ReservationsContributeur = dalReservation.ObtenirToutesLesReservations().Where(r => r.UtilisateurId == UtilisateurId).ToList()
            };

            return View("ListeCovoiturageContributeur", svm);
        }


        /******************Colis*******************/

        public ActionResult IndexColis(string lieu_collecte, string lieu_livraisaon, DateTime date_collecte) // affichage et recherche de colis
        {
            List<Colis> listeDescolis = dalService.ObtientTousLesColis();
            if (lieu_collecte != null)
            {
                return View(listeDescolis.Where(c => c.LieuDeCollecte.Contains(lieu_collecte)).ToList());
            }

            if (lieu_livraisaon != null)
            {
                return View(listeDescolis.Where(c => c.HeureDeLivraison.Contains(lieu_livraisaon)).ToList());
            }

            if (date_collecte.Year != 1)
            {
                return View(listeDescolis.Where(c => c.DateDeCollecte == date_collecte).ToList());
            }
            return View(listeDescolis);
        }

        //Ceer

        public IActionResult AjouterUnColis()
        {
            return View();
        }

      

        [HttpPost]
        public ActionResult AjouterUnColis(Colis colis)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
           

            colis.Etat = "En attente ";

            dalService.AjouterColis(colis.DateDeCreation, colis.Poids, colis.LieuDeCollecte, colis.DateDeCollecte, colis.HeureDeCollecte, colis.LieuDeLivraison, colis.HeureDeLivraison, colis.Prix, colis.Description, 3, UtilisateurId, colis.TailleColis,  colis.Etat) ;


            return Redirect("/Service/ListeCovoiturageContributeur");
        }
        public IActionResult ModifierUnColis(int? id)
        {

            if (id.HasValue)
            {
                Colis colis = dalService.ObtientTousLesColis().FirstOrDefault(r => r.Id == id.Value);
                if (colis == null)
                    return View("Error");



                return View(colis);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult ModifierUnColis(Colis colis)
        {

           

            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            dalService.ModifierColis(colis.Id, colis.Poids, colis.LieuDeCollecte, colis.DateDeCollecte, colis.HeureDeCollecte, colis.LieuDeLivraison, colis.HeureDeLivraison, colis.Prix, colis.Description, 3, UtilisateurId, colis.TailleColis, colis.Etat);
                                      
            return Redirect("/Service/ListeCovoiturageContributeur");
        }
        //*****************Supprimer Location ***********************************

        public ActionResult SupprimerUnColis(int id)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            dalService.SupprimerColis(id);
            
            return Redirect("/Home/Index");
        }












    }
}
