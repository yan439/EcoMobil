// Yannick

using EcoMobil.Models.Comptabilite;
using EcoMobil.Models.ManagementService;
using EcoMobil.Models.Personne;
using EcoMobil.Models.Services;
using System;
using System.Collections.Generic;

namespace EcoMobil.ViewModels
{
    public class TresorerieViewModel
    {
        public DateTime Date { get; set; }

        public Service Service { get; set; }

        public Utilisateur Utilisateur { get; set; }

        public List<Utilisateur> Utilisateurs { get; set; }

        public Covoiturage Covoiturage { get; set; }

        public List<Covoiturage> Covoiturages { get; set; }

        public List<Covoiturage> CovoituragesContributeur { get; set; }

        public Compte CompteConsommateur { get; set; }

        public Compte CompteContributeur { get; set; }

        public Compte CompteEcoMobil { get; set; }


    }
}