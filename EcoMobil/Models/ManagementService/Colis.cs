// Hamid

using EcoMobil.Models.Personne;
using System;
using System.ComponentModel.DataAnnotations;

namespace EcoMobil.Models.ManagementService
{
    public class Colis
    {
        public int Id { get; set; }

        public DateTime DateDeCreation { get; set; }

        //****************************Attributs******************************************//
        [Required(ErrorMessage = "Ce champ est obligatoire")]
       
        public int Poids { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Lieu de collecte")]
        public string LieuDeCollecte { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Date de collecte")]
        [DisplayFormat(DataFormatString = "{ dd-MM-YYYY }", ApplyFormatInEditMode = true)]
        public DateTime DateDeCollecte { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Heure de départ")]
        public string HeureDeCollecte { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Lieu de livraison")]
        public string LieuDeLivraison { get; set; }

       /* [Required(ErrorMessage = "Ce champ est obligatoire")]*/
        [Display(Name = "Heure de livraison ")]
        public string HeureDeLivraison { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Prix par colis")]
        public double Prix { get; set; }

      /*  [Required(ErrorMessage = "Ce champ est obligatoire")]*/
        public string Description { get; set; }

        public string TailleColis { get; set; }

        //public List<Reservation> Passagers { get; set; }

        //public Covoiturage()
        //{
        //    Passagers = new List<Reservation>();
        //}

        public enum TypeColis
        {
           Petit,
           Moyen,
           Grand
        }

        public string Etat { get; set; }


        //**************************clé secondaire*************************//

        [Required]
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public int UtilisateurId { get; set; }

        public Utilisateur Utilisateur { get; set; }

        //public int JustificatifId { get; set; }

        //public Justificatif Justificatif { get; set; }


    }
}
