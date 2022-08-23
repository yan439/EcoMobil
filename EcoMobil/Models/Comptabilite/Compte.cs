// Yannick

using EcoMobil.Models.Personne;

namespace EcoMobil.Models.Comptabilite
{
    public class Compte
    {
        public int Id { get; set; }

        public string IBAN { get; set; }

        public double Solde { get; set; }

        public string NumeroDeCarte { get; set; }

        public string DateFinValidite { get; set; }

        public string Cryptogramme { get; set; }

        public int UtilisateurId { get; set; }

        public Utilisateur Utilisateur { get; set; }
    }
}
