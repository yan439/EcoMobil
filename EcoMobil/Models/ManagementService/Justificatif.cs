// Yannick

namespace EcoMobil.Models.ManagementService
{
    public class Justificatif
    {
        public int Id { get; set; }
        
        public bool PermisDeConduire { get; set; }

        public bool CertificatDImmatriculation { get; set; }

        public bool Assurance { get; set; }

        public bool ControleTechnique { get; set; }
    }
}
