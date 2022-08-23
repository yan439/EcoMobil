// Yannick

using EcoMobil.Models.Personne;
using System.ComponentModel.DataAnnotations;

namespace EcoMobil.Models.ManagementService
{
    public class Message
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Heure { get; set; }

        public string Destinataire { get; set; }

        [Display(Name = "Objet")]
        public string ObjetDuMessage { get; set; }

        [Display(Name = "Message")]
        public string CorpsDuMessage { get; set; }

        public string EtatCoteExpediteur { get; set; }

        public string EtatCoteDestinataire { get; set; }

        public int UtilisateurId { get; set; }

        public Utilisateur Utilisateur { get; set; }
    }
}