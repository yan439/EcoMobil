// Houda

using EcoMobil.Models.Personne;
using EcoMobil.Models.Services;
using EcoMobil.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EcoMobil.Controllers
{
    [Authorize]
    public class ProfilController : Controller
    {

        private DalUtilisateur dal;

 
        public ProfilController()
        {
        
            dal = new DalUtilisateur();
        }
        public IActionResult Index()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            HomeViewModel hvm = new HomeViewModel
            {

            };

            return View(hvm);
        }

        public IActionResult CoordonneesUtilisateur()
        {
            int utilisateur = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            List<Utilisateur> list = dal.ObtientTousLesUtilisateurs().Where(u => u.Id == utilisateur).ToList();

            return View(list);
        }

        public IActionResult ModifierUtilisateur(int id)
        {
            if (id != 0)
            {
                using (DalUtilisateur dal = new DalUtilisateur())
                {
                    Utilisateur utilisateur = dal.ObtientTousLesUtilisateurs().Where(r => r.Id == id).FirstOrDefault();
                    if (utilisateur == null)
                    {

                        return View("Error");
                    }
                    return View(utilisateur);
                }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifierUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return View(utilisateur);

            if (utilisateur.Id != 0)
            {
                using (DalUtilisateur ctx = new DalUtilisateur())
                {
                    
                    ctx.ModifierUtilisateur(utilisateur);

                    return View(utilisateur);

                }

            }
            else
            {
                return View("Error");
            }
        }


        public ActionResult SupprimerMonCompte(int id)
        {
            dal.SupprimerUtilisateur(id);
            HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
        

    

