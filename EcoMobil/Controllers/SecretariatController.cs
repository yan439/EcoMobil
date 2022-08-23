// Houda, Yannick, Hamid

using EcoMobil.Models.BDD;
using EcoMobil.Models.ManagementService;
using EcoMobil.Models.Personne;
using EcoMobil.Models.Services;
using EcoMobil.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EcoMobil.Controllers
{
    public class SecretariatController : Controller
    {
        private DalSecretariat dalSecretariat;

        private DalService dalService;

        private DalUtilisateur dalUtilisateur;

        private DalReservation dalReservation;

        private DalMessage dalMessage;


        public SecretariatController()
        {
            dalSecretariat = new DalSecretariat();
            dalService = new DalService();
            dalUtilisateur = new DalUtilisateur();
            dalReservation = new DalReservation();
            dalMessage = new DalMessage();
        }

        /**********METHODE DE RECHERCHE*******************************************/



        public IActionResult RechercheSecretariat(string type_service, string nom_contributeur, string etat_service)
        {

            List<Covoiturage> listeCovoiturage = dalService.ObtientTousLesCovoiturages().ToList();


            if (type_service != null)
            {
                listeCovoiturage = listeCovoiturage.Where(c => c.Service.TypeService.Contains(type_service)).ToList();
            }

            if (nom_contributeur != null)
            {
                listeCovoiturage = listeCovoiturage.Where(c => c.Utilisateur.Nom.Contains(nom_contributeur)).ToList();
            }

            if (etat_service != null)
            {
                listeCovoiturage = listeCovoiturage.Where(c => c.Etat.Contains(etat_service)).ToList();
            }

            SecretariatViewModel svm = new SecretariatViewModel
            {
                Covoiturages = listeCovoiturage,

                Utilisateurs = dalUtilisateur.ObtientTousLesUtilisateurs().ToList(),

                Locations = dalService.ObtientTousLesLocations().ToList(),
                LesColis =dalService.ObtientTousLesColis().ToList()
            };

            return View("IndexSecretariat",svm);
        }

        public IActionResult IndexSecretariat()
        {
            SecretariatViewModel svm = new SecretariatViewModel
            {
                Covoiturages = dalService.ObtientTousLesCovoiturages().OrderByDescending(c => c.DateDeCreation).ToList(),
                Locations = dalService.ObtientTousLesLocations().ToList(),
                
                Reservations = dalReservation.ObtenirToutesLesReservations().ToList(),
                LesColis = dalService.ObtientTousLesColis().ToList(),
            };

            return View(svm);
        }

        public IActionResult Index()
        {
            SecretariatViewModel svm = new SecretariatViewModel
            {
                Utilisateurs = dalUtilisateur.ObtientTousLesUtilisateurs().OrderBy(u => u.Nom).ToList(),                
            };

            return View(svm);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult PublierCovoiturage(int id)
        {
            if (id != 0)
            {
                dalSecretariat.ValiderCovoiturage(id);
                return RedirectToAction("IndexSecretariat");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult RejeterCovoiturage(int id)
        {
            if (id != 0)
            {
                dalSecretariat.RejeterCovoiturage(id);
                return RedirectToAction("IndexSecretariat");
            }
            else
            {
                return View("Error");
            }
        }
        //***********************************************************Location
        public ActionResult PublierLocation(int id)
        {
            if (id != 0)
            {
                dalSecretariat.ValiderLocation(id);

                return RedirectToAction("IndexSecretariat");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult RejeterLocation(int id)
        {
            if (id != 0)
            {
                dalSecretariat.RejeterLocation(id);

                return RedirectToAction("IndexSecretariat");
            }
            else
            {
                return View("Error");
            }
        }
        //****************************Publier Colis**************************//
        public ActionResult PublierColis(int id)
        {
            if (id != 0)
            {
                dalSecretariat.ValiderColis(id);
                return RedirectToAction("IndexSecretariat");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult RejeterColis(int id)
        {
            if (id != 0)
            {
                dalSecretariat.RejeterColis(id);

                return RedirectToAction("IndexSecretariat");
            }
            else
            {
                return View("Error");
            }
        }
//*****************************MESSAGERIE********************************//

        public ActionResult EnvoyerMessage(int IdDestinataire)
        {
            Utilisateur destinataire = dalUtilisateur.ObtenirCompte(IdDestinataire);
            Message message = new Message { Destinataire = destinataire.Nom.ToUpper() + " " + destinataire.Prenom };
            SecretariatViewModel svm = new SecretariatViewModel { Message = message };

            return View(svm);
        }

        [HttpPost]
        public ActionResult EnvoyerMessage(Message Message)
        {
            int IdExpediteur = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            dalMessage.AjouterMessage
            (
                DateTime.Now.ToShortDateString(),
                DateTime.Now.ToShortTimeString(),
                Message.Destinataire,
                Message.ObjetDuMessage,
                Message.CorpsDuMessage,
                "Envoyé",
                "Non lu",
                IdExpediteur
            );

            return RedirectToAction("MaMessagerie");
        }

        public ActionResult MaMessagerie()
        {
            int UtilisateurId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Utilisateur utilisateur = dalUtilisateur.ObtenirCompte(UtilisateurId);
            string Destinataire = utilisateur.Nom.ToUpper() + " " + utilisateur.Prenom;

            SecretariatViewModel svm = new SecretariatViewModel
            {
                Messages = dalMessage.ObtenirTousLesMessages().ToList(),
                MessagesRecus = dalMessage.ObtenirTousLesMessages().Where(m => m.Destinataire == Destinataire).ToList(),
                MessagesEnvoyes = dalMessage.ObtenirTousLesMessages().Where(m => m.UtilisateurId == UtilisateurId).ToList(),
            };

            return View(svm);
        }

        public ActionResult SupprimerMessage(int id, string EtatCoteExpediteur, string EtatCoteDestinataire)
        {
            Message message = dalMessage.ObtenirMessage(id);
            message.EtatCoteExpediteur = EtatCoteExpediteur;
            message.EtatCoteDestinataire = EtatCoteDestinataire;
            dalMessage.ModifierMessage(message);

            if (message.EtatCoteExpediteur.Equals("Supprimé") && message.EtatCoteDestinataire.Equals("Supprimé"))
            {
                dalMessage.SupprimerMessage(message.Id);
            }

            return RedirectToAction("MaMessagerie");
        }
    }
}