// Houda, Hamid

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoMobil.Models.ManagementService
{
    public class Vehicule
    {
        public int Id { get; set; }

        //**********************Attributs************************//


        [Display(Name = "Modèle")]
        public string Modele { get; set; }

        public bool Automatique { get; set; }


        [Required]
        public bool Electrique { get; set; }

        [Display(Name = "Nombre de Porte")]
        public int nombreDePortes { get; set; }

        [Display(Name = "Date d'expiration de controle technique")]
        public DateTime ControleTechnique { get; set; }

        public string Marque { get; set; }

        public enum MarqueType
        {
            Audi, 
            AlfaRomeo,
            Alpine,
            BMW,
            Bently,
            BRP,
            Bugatti,
            Chevrolet,
            Citroen,
            Cupra,
            Dacia,
            DS,
            Ford,
            Fiat,
            GMC,
            Honda,
            Hyundai,
            Hummer,
            Jeep,
            Kia,
            Lotus,
            Mercredes,
            MINI,
            Mitsubishi,
            Nissan,
            Opel,
            Peugeot,
            Porshe,
            Renault,
            Seat,
            Smart,
            Suzuki,
            Tesla,
            Toyota,
            Volkswagen,
            Volvo,


        }



        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }



        //**********************Clé secondaire************************//

       

 
    }
}