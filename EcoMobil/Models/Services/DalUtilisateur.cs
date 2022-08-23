// Houda

using EcoMobil.Models.BDD;
using EcoMobil.Models.Personne;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XSystem.Security.Cryptography;

namespace EcoMobil.Models.Services
{
    public class DalUtilisateur : IDisposable
    {
        private BddContext _bddContext;

        public DalUtilisateur()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
       

        //*******Gestion des utilisateurs**********//
        public List<Utilisateur> ObtientTousLesUtilisateurs()
        {
            return _bddContext.Utilisateurs.Include(s => s.Service).ToList();
        }

        //Ajouter
        public int AjouterUtilisateur(string Nom, string Prenom, string Telephone, string Email, string MotDePasse)
        {
            string MotDePasseCrypte = EncodeMD5(MotDePasse);

            Utilisateur utilisateur = new Utilisateur()
            {
                Nom = Nom,
                Prenom = Prenom,
                Telephone = Telephone,
                Email = Email,
                MotDePasse = MotDePasseCrypte,
                Role = Role.ReadWrite
            };

            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }
       

        //Modifier
        public void ModifierUtilisateur(int id, string Email, string MotDePasse,string Telephone, string Nom, string Prenom)
        {
            Utilisateur utilisateur = _bddContext.Utilisateurs.Find(id);

            if (utilisateur != null)
            {
                utilisateur.Email = Email;
                utilisateur.MotDePasse = MotDePasse;
                utilisateur.Telephone = Telephone;
                utilisateur.Nom = Nom;
                utilisateur.Prenom = Prenom;

                _bddContext.SaveChanges();
            }
        }
        public void ModifierUtilisateur(Utilisateur utilisateur)
        {
            _bddContext.Utilisateurs.Update(utilisateur);
            _bddContext.SaveChanges();
        }

        //Supprimer
        public void SupprimerUtilisateur(int id)
        {
            Utilisateur utilisateur = _bddContext.Utilisateurs.Find(id);

            if (utilisateur != null)
            {
                _bddContext.Utilisateurs.Remove(utilisateur);
                _bddContext.SaveChanges();
            }
        }
    
        //***************************Gestion Des comptes utilisateurs********************************* *********//

        public Utilisateur Authentifier(string Email, string MotDePasse)
        {
            string motDePasse = EncodeMD5(MotDePasse);
            Utilisateur utilisateur = this._bddContext.Utilisateurs.FirstOrDefault(u => u.Email == Email && u.MotDePasse == MotDePasse);
            return utilisateur;
        }

        public Utilisateur ObtenirCompte(int id)
        {
            return this._bddContext.Utilisateurs.FirstOrDefault(u => u.Id == id);
        }

        public Utilisateur ObtenirCompte(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirCompte(id);
            }
            return null;
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "EcoMobil" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
        //***************************Gestion Des comptes administrateurss********************************* *********//
    }
}




