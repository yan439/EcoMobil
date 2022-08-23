// Houda

using EcoMobil.Models.Personne;
using System;
using System.ComponentModel.DataAnnotations;

namespace EcoMobil.Models.ManagementService
{
    public class Don
    {
        public int Id { get; set; }

        public DateTime DateDeDon { get; set; }

		[Required(ErrorMessage = "Ce champ est obligatoire")]
		public  double Somme { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Nom { get; set; }

        public string Prenom { get; set; }


    }
}
