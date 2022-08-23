// Yannick

using EcoMobil.Models.BDD;
using EcoMobil.Models.ManagementService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EcoMobil.Models.Services
{
    public class DalReservation
    {
        private BddContext _bddContext;

        public DalReservation()
        {
            _bddContext = new BddContext();
        }

        public void AjouterReservation(string Date, string Etat, int UtilisateurId, int CovoiturageId)
        //public void AjouterReservation(string Date, string Etat, int UtilisateurId, int CovoiturageId)
        //public void AjouterReservation(string Date, string Etat, int UtilisateurId, int? CovoiturageId, int? LocationId)
        {

            Reservation reservation = new Reservation { 
                Date = Date,
                Etat = Etat,
                UtilisateurId = UtilisateurId,
                CovoiturageId = CovoiturageId
                //LocationId = LocationId
            };
                _bddContext.Reservations.Add(reservation);
                _bddContext.SaveChanges();
            
        }

        public List<Reservation> ObtenirToutesLesReservations()
        {
            return _bddContext.Reservations.Include(r => r.Utilisateur).Include(r => r.Covoiturage)/*.Include(r => r.Location)*/.ToList();
        }

        public Reservation ObtenirReservation(int id)
        {
            return this._bddContext.Reservations.FirstOrDefault(r => r.Id == id);
        }

        public void AccepterReservation(int Id)
        {
            Reservation reservation = _bddContext.Reservations.Find(Id);

            if (reservation != null)
            {
                reservation.Etat = "Acceptée";

                _bddContext.SaveChanges();
            }
        }

        public void RefuserReservation(int Id)
        {
            Reservation reservation = _bddContext.Reservations.Find(Id);

            if (reservation != null)
            {
                reservation.Etat = "Refusée";

                _bddContext.SaveChanges();
            }
        }

        public void SupprimerReservation(int id)
        {
            Reservation reservation = _bddContext.Reservations.Find(id);

            if (reservation != null)
            {
                _bddContext.Reservations.Remove(reservation);
                _bddContext.SaveChanges();
            }
        }
    }

}
