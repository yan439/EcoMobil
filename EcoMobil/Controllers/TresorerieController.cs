// Yannick

using EcoMobil.Models.Comptabilite;
using EcoMobil.Models.ManagementService;
using EcoMobil.Models.Services;
using EcoMobil.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace EcoMobil.Controllers
{
    public class TresorerieController : Controller
    {
        private DalSecretariat dalSecretariat;

        private DalService dalService;

        private DalUtilisateur dalUtilisateur;

        private DalReservation dalReservation;

        private DalMessage dalMessage;

        private DalCompte dalCompte;

        public TresorerieController()
        {
            dalSecretariat = new DalSecretariat();
            dalService = new DalService();
            dalUtilisateur = new DalUtilisateur();
            dalReservation = new DalReservation();
            dalMessage = new DalMessage();
            dalCompte = new DalCompte();
        }
        
        public IActionResult PayerService(int id)
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Reservation reservation = dalReservation.ObtenirReservation(id);
            Covoiturage covoiturage = dalService.ObtenirCovoiturage(reservation.CovoiturageId);
            Covoiturage covoiturage2 = reservation.Covoiturage;
            Compte compteADebiter = dalCompte.ObtenirTousLesComptes().Where(c => c.UtilisateurId == UtilisateurId).FirstOrDefault();
            Compte compteACrediter = dalCompte.ObtenirTousLesComptes().Where(c => c.UtilisateurId == covoiturage.UtilisateurId).FirstOrDefault();
            TresorerieViewModel tvm = new TresorerieViewModel
            {
                CompteConsommateur = compteADebiter,
                CompteContributeur = compteACrediter
            };

            return View(tvm);
        }

        //[HttpPost]
        //public IActionResult PayerService(double Prix)
        //{
        //    int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //    Reservation reservation = dalReservation.ObtenirReservation(id);
        //    Covoiturage covoiturage = new Covoiturage();
        //    Compte compteADebiter = dalCompte.ObtenirTousLesComptes().fi
        //        Compte compteACrediter = new C

        //    dalCompte.ModifierCompte(compteADebiter);
        //    dalCompte.ModifierCompte(compteACrediter);

        //    return View();
        //}

        //public IActionResult PreleverCommission(int id)
        //{
        //    int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //    Reservation reservation = dalReservation.ObtenirReservation(id);
        //    Compte compteADebiter = new C
        //        Compte compteACrediter = new C

        //    dalCompte.ModifierCompte(compteADebiter);
        //    dalCompte.ModifierCompte(compteACrediter);

        //    return View();
        //}
    }
}
