// Houda

using EcoMobil.Models.ManagementService;
using EcoMobil.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace EcoMobil.Controllers
{
    public class DonController : Controller
    {
        private DalPaie dal;


        public DonController()
        {

            dal = new DalPaie();
        }

        public IActionResult CreerDon(int Id)
        {
            dal.ObtenirToutesLesDons().Where(r => r.Id == Id).FirstOrDefault();

            return View();

        }
        public IActionResult FaireUnDon()
        {

            return View();
        }

        [HttpPost]
        public IActionResult FaireUnDon(Don don)
        {

            int donId = dal.FaireUnDon(DateTime.Now, don.Nom, don.Prenom, don.Email, don.Somme);


            return Redirect("/Don/Payement/" + donId);
        }

        public IActionResult Payement(int id)
        {
            if (id != 0)
            {
                Don don = dal.ObtenirToutesLesDons().Where(r => r.Id == id).FirstOrDefault();
                Paie paie = new Paie(don.Somme, don.Id);

                if (don == null)
                {
                    return View("Error");
                }
                return View(paie);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult Payement(Paie paie)
        {
            if (!ModelState.IsValid)
                return View(paie);

            if (paie.Id != 0)
            {

                foreach (Paie p in dal.ObtenirToutesLesPaies())
                {
                    if ((p.NumeroCB == paie.NumeroCB) && (p.Crypto == paie.Crypto) && (p.DateExpirationMois == paie.DateExpirationMois) && (p.DateExpirationAnnee == paie.DateExpirationAnnee))
                    {
                        if (p.Solde > paie.Don.Somme)
                        {
                            return View("Transcationapproved");

                        }

                    }
                }


                Don don = dal.ObtenirToutesLesDons().Where(r => r.Id == paie.DonId).FirstOrDefault();
                dal.AnnulerDon(don.Id);
                return View("Transactionfailed");

            }

            else
            {
                return View("Error");
            }
        }


    }
}



