// Houda

using EcoMobil.Models.ManagementService;
using EcoMobil.Models.Personne;
using System;

namespace EcoMobil.ViewModels
{
    public class HomeViewModel
    {
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public Utilisateur Utilisateur { get; set; }

        public Vehicule Vehicules { get; set; }

        public Service Service { get; set; }

        public Covoiturage Covoiturage { get; set; }

        public bool Authentification { get; set; }

        //***********************CreerService**********************//
        
    }
}
