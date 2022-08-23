// Houda

using EcoMobil.Models.BDD;
using EcoMobil.Models.ManagementService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcoMobil.Models.Services
{
    public class DalPaie
    {

        private BddContext _bddContext;
        public DalPaie()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<Don> ObtenirToutesLesDons()
        {
            return _bddContext.Dons.ToList();

        }

        public List<Paie> ObtenirToutesLesPaies()
        {


            return _bddContext.Paies.ToList();
        }

        public int FaireUnDon(DateTime Creation, string Nom, string Prenom, string Email, double Somme)
        {
            Don don = new Don()
            {
                Nom = Nom,
                Prenom = Prenom,
                Email = Email,
                Somme = Somme,


            };

            _bddContext.Dons.Add(don);
            _bddContext.SaveChanges();

            return don.Id;

        }
        public void FaireUnDon(Don don)
        {
            _bddContext.Dons.Update(don);
            _bddContext.SaveChanges();
        }

        public void AnnulerDon(int id)
        {
            Don don = _bddContext.Dons.Find(id);

            if (don != null)
            {
                _bddContext.Dons.Remove(don);
                _bddContext.SaveChanges();
            }




        }


    }
}
