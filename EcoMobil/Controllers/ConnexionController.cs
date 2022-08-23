// Houda, Yannick

using EcoMobil.Models.Personne;
using EcoMobil.Models.Services;
using EcoMobil.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace EcoMobil.Controllers
{
    public class ConnexionController : Controller
    {
        private DalUtilisateur dalUtilisateur;

        public ConnexionController()
        {
            dalUtilisateur = new DalUtilisateur();
        }

        public IActionResult IndexConnexion()
        {
            HomeViewModel viewModel = new HomeViewModel { Authentification = HttpContext.User.Identity.IsAuthenticated };

            if (viewModel.Authentification)
            {
                var idUtilisateur = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                viewModel.Utilisateur = dalUtilisateur.ObtenirCompte(idUtilisateur);

                return Redirect("/home/index");
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult IndexConnexion(HomeViewModel viewModel, string returnUrl)
        {
            Utilisateur utilisateur = dalUtilisateur.Authentifier(viewModel.Utilisateur.Email, viewModel.Utilisateur.MotDePasse);

            if (utilisateur != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, utilisateur.Email),
                    new Claim(ClaimTypes.NameIdentifier, utilisateur.Id.ToString()),
                    new Claim(ClaimTypes.Name, utilisateur.Prenom + " " + utilisateur.Nom),
                    new Claim(ClaimTypes.Role, utilisateur.Role.ToString())
                };

                var claimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { claimIdentity });

                HttpContext.SignInAsync(userPrincipal);

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return Redirect("/");
            }

            ModelState.AddModelError("Utilisateur.Email", "Email et/ou mot de passe incorrect(s)");

            return View(viewModel);
        }


        


        public ActionResult CreerCompte()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerCompte(Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {                
                int id = dalUtilisateur.AjouterUtilisateur(utilisateur.Nom, utilisateur.Prenom, utilisateur.Telephone, utilisateur.Email, utilisateur.MotDePasse);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Name, utilisateur.Prenom + " " + utilisateur.Nom.ToUpper()),
                    new Claim(ClaimTypes.GivenName, utilisateur.Prenom),
                    new Claim(ClaimTypes.HomePhone, utilisateur.Telephone),
                    new Claim(ClaimTypes.Email, utilisateur.Email),
                };

                var claimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { claimIdentity });

                HttpContext.SignInAsync(userPrincipal);

                return Redirect("/");
            }

            return View(utilisateur);
        }

        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}