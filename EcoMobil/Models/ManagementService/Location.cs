// Houda

using EcoMobil.Models.Personne;
using System;
using System.ComponentModel.DataAnnotations;

namespace EcoMobil.Models.ManagementService
{
    public class Location

    {
        public int Id { get; set; }
        public DateTime DateDeCreation { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Disponible dès le")]
        public DateTime Disponible { get; set; }

        [Display(Name = "Lieu de récupération")]
        public string LieuDeDepot { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Prix par jour")]
        public double PrixParJour { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Description { get; set; }

        public string Etat { get; set; }


        //**********************cle secondaire**************//

        public int UtilisateurId { get; set; }
        
        public Utilisateur Utilisateur { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public int VehiculeId { get; set; }
        
        public Vehicule Vehicule { get; set; }
    }
}