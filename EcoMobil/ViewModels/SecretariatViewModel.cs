// Houda, Yannick, Hamid

using EcoMobil.Models.ManagementService;
using EcoMobil.Models.Personne;
using EcoMobil.Models.Services;
using System;
using System.Collections.Generic;

namespace EcoMobil.ViewModels
{
    public class SecretariatViewModel
    {
        public DateTime Date { get; set; }

        public Service Service { get; set; }

        public Utilisateur Utilisateur { get; set; }
         
        public List<Utilisateur> Utilisateurs { get; set; }

        public Covoiturage Covoiturage { get; set; }

        public List<Covoiturage> Covoiturages { get; set; }

        public List<Covoiturage> CovoituragesContributeur { get; set; }

        public Location Location { get; set; }

        public List<Location> Locations { get; set; }

        public List<Location> LocationsContributeur { get; set; }

        public Colis Colis { get; set; }

        public List<Colis>LesColis { get; set; }

        public List<Colis> ColisContributeur { get; set; }

        public Reservation Reservation { get; set; }

        public List<Reservation> Reservations { get; set; }
 
        public List<Reservation> ReservationsContributeur { get; set; }

        public List<Reservation> ReservationsConsommateurs { get; set; }

        public Justificatif Justificatif { get; set; }

        public Vehicule Vehicule { get; set; }

        public Message Message { get; set; }

        public List<Message> Messages { get; set; }

        public List<Message> MessagesRecus { get; set; }

        public List<Message> MessagesEnvoyes { get; set; }
    }
}