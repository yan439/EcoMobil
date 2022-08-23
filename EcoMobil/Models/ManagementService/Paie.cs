// Houda

using System.ComponentModel.DataAnnotations;

namespace EcoMobil.Models.ManagementService
{
    public class Paie
    {
        public double Somme { get; set; }

        public Paie(double somme, int donId)
        {
            Somme = somme;
            DonId = donId;
        }

        public int Id { get; set; }
        [Display(Name = "Numéro de la carte bancaire")]
        public string NumeroCB { get; set; }

        [Display(Name = "Date d'expiration")]
        public string DateExpirationMois { get; set; }

        public string DateExpirationAnnee { get; set; }

        [Display(Name = "Code de vérification")]
        public string Crypto { get; set; }

        [Display(Name = "Nom de titulaire de la carte")]
        public string TitulaireCarte { get; set; }
        public double Prix { get; set; }
        //public double Montant { get; set; }

        public double Solde { get; set; }

        public Don Don { get; set; }

        public int DonId { get; set; }
    }
}
