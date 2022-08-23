// Houda

using EcoMobil.Models.Personne;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoMobil.Models.ManagementService
{
    public class Covoiturage
    {
     

        public int Id { get; set; }

        public DateTime DateDeCreation { get; set; }

        //****************************Attributs******************************************//
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Nombre de place disponible")]
        public int PlaceDisponible { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Lieu de départ")]
        public string LieuDeDepart { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Date de départ")]
        [DisplayFormat(DataFormatString = "{ dd-MM-YYYY }", ApplyFormatInEditMode = true)]
        public DateTime DateDeDepart { get; set; }
       
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Heure de départ")]
        public string HeureDeDepart { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Lieu d'arrivée")]
        public string LieuDArrivee { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Heure d'arrivée ")]
        public string HeureDArrivee { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Prix par place")]
        public double Prix { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Description { get; set; }

        public string Etat { get; set; }

        //public List<Reservation> Passagers { get; set; }

        //public Covoiturage()
        //{
        //    Passagers = new List<Reservation>();
        //}

        //public enum EtatType
        //{
        //    EnAttenteDeValidation,
        //    Publie,
        //    Rejete
        //}

        
        //**************************clé secondaire*************************//

        [Required]
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public int VehiculeId { get; set; }

        public Vehicule Vehicule { get; set; }

        public int UtilisateurId { get; set; }

        public Utilisateur Utilisateur { get; set; }

        //public int JustificatifId { get; set; }

        //public Justificatif Justificatif { get; set; }
    }
}