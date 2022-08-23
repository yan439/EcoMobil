// Yannick

using EcoMobil.Models.Personne;
using System;

namespace EcoMobil.Models.ManagementService
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Etat { get; set; }

        public int UtilisateurId { get; set; }

        public Utilisateur Utilisateur { get; set; }

        //public int ServiceId { get; set; }

        //public Service Service { get; set; }

        public int CovoiturageId { get; set; }

        public Covoiturage Covoiturage { get; set; }

        //public int LocationId { get; set; }

        //public Location Location { get; set; }
    }
}