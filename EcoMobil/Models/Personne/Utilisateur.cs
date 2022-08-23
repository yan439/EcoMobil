// Houda

using EcoMobil.Models.ManagementService;
using System.ComponentModel.DataAnnotations;

namespace EcoMobil.Models.Personne
{
    public class Utilisateur
    {
        public int Id { get; set; }

        //Attributs
        [Required]
        public string Nom { get; set; }

        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Display(Name = "Téléphone")]
        [MaxLength(10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Le numéro de téléphone doit contenir 10 chiffres.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Veuillez saisir une adresse mail valide")]
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Votre mot de passe doit contenir au moins huit caractères dont :" +
                           " Une lettre majuscule" +
                           " Une lettre minuscule" +
                           " Un chiffre" +
                           " Un caractère spécial")]
        public string MotDePasse { get; set; }
        
        public Role Role { get; set; }

        public string Statut { get; set; }



        //Clé secondaire
        public int? ServiceId { get; set; }

        public Service Service { get; set; }
       
    }
    public enum Role
    {
        Admin,
        ReadWrite,
        //ReadOnly
    }
}