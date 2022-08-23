// Yannick

using EcoMobil.Models.BDD;
using EcoMobil.Models.Comptabilite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XSystem.Security.Cryptography;

namespace EcoMobil.Models.Services
{
    public class DalCompte
    {
        private BddContext _bddContext;

        public DalCompte()
        {
            _bddContext = new BddContext();
        }

        public void AjouterCompte(string IBAN, double Solde, string NumeroDeCarte, string DateFinValidite, string Cryptogramme, int IdUtilisateur)
        {
            Compte compte = new Compte
            {
                IBAN = IBAN,
                Solde = Solde,
                NumeroDeCarte = EncodeMD5(NumeroDeCarte),
                DateFinValidite = EncodeMD5(DateFinValidite),
                Cryptogramme = EncodeMD5(Cryptogramme),
                UtilisateurId = IdUtilisateur
            };

            _bddContext.Comptes.Add(compte);
            _bddContext.SaveChanges();
        }

        public List<Compte> ObtenirTousLesComptes()
        {
            return _bddContext.Comptes.Include(c => c.Utilisateur).ToList();
        }

        public Compte ObtenirCompte(int id)
        {
            return this._bddContext.Comptes.FirstOrDefault(c => c.Id == id);
        }

        public void ModifierCompte(Compte compte)
        {
            _bddContext.Comptes.Update(compte);
            _bddContext.SaveChanges();
        }

        public void SupprimerCompte(int id)
        {
            Compte compte = _bddContext.Comptes.Find(id);

            if (compte != null)
            {
                _bddContext.Comptes.Remove(compte);
                _bddContext.SaveChanges();
            }
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "EcoMobil" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
    }
}
