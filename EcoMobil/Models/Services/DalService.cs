// Houda, Yannick, Hamid

using EcoMobil.Models.BDD;
using EcoMobil.Models.ManagementService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EcoMobil.Models.Services
{
    public class DalService : IDisposable
    {
        private BddContext _bddContext;

        public DalService()
        {
            _bddContext = new BddContext();
        }
        public void Dispose()
        {
            _bddContext.Dispose();
        }
        //*****************************Gestion des véhicules*********************************************//
        public List<Vehicule> ObtientTousLesVehicules()
        {
            return _bddContext.Vehicules.ToList();

        }

        //Ajouter
        public int AjouterVehicule(string Modele, bool Automatique, string Marque, bool Electrique, int nombreDePortes, DateTime ControleTechnique)
        {

            Vehicule vehicule = new Vehicule()
            {
                Modele = Modele,
                Automatique = Automatique,
                Marque = Marque,
                Electrique = Electrique,
                nombreDePortes = nombreDePortes,
                ControleTechnique = ControleTechnique,
            };

            _bddContext.Vehicules.Add(vehicule);
            _bddContext.SaveChanges();

            return vehicule.Id;

        }
        public void AjouterVehicule(Vehicule vehicule)
        {
            _bddContext.Vehicules.Update(vehicule);
            _bddContext.SaveChanges();
        }

        //Modifier
        public void ModifierVehicule(int Id, string Modele, string Marque, bool Automatique, bool Electrique, int nombreDePortes, DateTime ControleTechnique)
        {
            Vehicule vehicule = _bddContext.Vehicules.Find(Id);

            if (vehicule != null)
            {
                vehicule.Modele = Modele;
                vehicule.Automatique = Automatique;
                vehicule.Electrique = Electrique;
                vehicule.Marque = Marque;
                vehicule.nombreDePortes = nombreDePortes;
                vehicule.ControleTechnique = ControleTechnique;

                _bddContext.SaveChanges();
            }
        }
        public void ModifierVehicule(Vehicule vehicule)
        {
            _bddContext.Vehicules.Update(vehicule);
            _bddContext.SaveChanges();
        }
        //Supprimer
        public void SupprimerVehicule(int id)
        {
            Vehicule vehicule = _bddContext.Vehicules.Find(id);

            if (vehicule != null)
            {
                _bddContext.Vehicules.Remove(vehicule);
                _bddContext.SaveChanges();
            }
        }
        //*****************************Gestion des services*********************************************//


        public List<Service> ObtientTousLesServices()

        {
            return _bddContext.Services.ToList();
        }


        //Ajouter
        public int AjouterService(string TypeService)
        {
            Service service = new Service() {
                TypeService = TypeService,
 
            };
 
            _bddContext.Services.Add(service);
            _bddContext.SaveChanges();

            return service.Id;
           
        }


        //lire Le Choix

        public int LireTypeService(string TypeService)
        {
            Service service = _bddContext.Services.Where(r => r.TypeService == TypeService).FirstOrDefault();
            return service.Id;
        }

        //Modifier
        public void ModifierService(int Id,String TypeService)
        {
            Service service = _bddContext.Services.Find(Id);

            if (service != null)
            {
                service.Id = Id;
                service.TypeService = TypeService;
 
                _bddContext.SaveChanges();
            }
        }
        public void ModifierService(Service service)
        {
            _bddContext.Services.Update(service);
            _bddContext.SaveChanges();
        }
        //Supprimer
        public void SupprimerService(int id)
        {
            Service service = _bddContext.Services.Find(id);

            if (service != null)
            {
                _bddContext.Services.Remove(service);
                _bddContext.SaveChanges();
            }
        }
        public void SupprimerService(String TypeService)
        {
            Service service = _bddContext.Services.Where(r => r.TypeService == TypeService ).FirstOrDefault();
            if (service != null)
            {
                this._bddContext.Services.Remove(service);
                this._bddContext.SaveChanges();
            }
        }

        //*****************************Gestion des covoiturages*********************************************//

        public List<Covoiturage> ObtientTousLesCovoiturages()
        {

            return _bddContext.Covoiturages.Include(c => c.Service).Include(c => c.Vehicule).Include(c => c.Utilisateur)/*.Include(c => c.Justificatif)*/.ToList();

        }


        public Covoiturage ObtenirCovoiturage(int id)
        {
            return this._bddContext.Covoiturages.FirstOrDefault(c => c.Id == id);
        }



        //Ajouter



        public int AjouterCovoiturage(int PlaceDisponible, string LieuDeDepart, DateTime DateDeDepart, string HeureDeDepart, string LieuDArrivee,  string HeureDArrivee,  double Prix, string Description, int ServiceId, int VehiculeId,int UtilisateurId, string Etat)
        {
            Covoiturage covoiturage = new Covoiturage()
            {
                DateDeCreation = DateTime.Now,
                PlaceDisponible = PlaceDisponible,
                LieuDeDepart = LieuDeDepart,
                DateDeDepart = DateDeDepart,
                HeureDeDepart = HeureDeDepart,
                LieuDArrivee = LieuDArrivee,
                HeureDArrivee = HeureDArrivee,    
                Prix = Prix,
                Description = Description,
                Etat = Etat,
                ServiceId = ServiceId,
                VehiculeId = VehiculeId,
                UtilisateurId = UtilisateurId,


            };

            _bddContext.Covoiturages.Add(covoiturage);
            _bddContext.SaveChanges();

            return covoiturage.Id;

        }
        public void AjouterCovoiturage(Covoiturage covoiturage)
        {
            _bddContext.Covoiturages.Update(covoiturage);
            _bddContext.SaveChanges();
        }


        public void ModifierCovoiturage(int Id, int PlaceDisponible, string LieuDeDepart, DateTime DateDeDepart, string HeureDeDepart, string LieuDArrivee,  string HeureDArrivee,  double Prix, string Description,string Etat, int ServiceId, int VehiculeId, int UtilisateurId)
        { 
            Covoiturage covoiturage = _bddContext.Covoiturages.Find(Id);

            if (covoiturage != null)

            {


                covoiturage.PlaceDisponible = PlaceDisponible;
                covoiturage.LieuDeDepart = LieuDeDepart;
                covoiturage.DateDeDepart = DateDeDepart;
                covoiturage.HeureDeDepart = HeureDeDepart;
                covoiturage.LieuDArrivee = LieuDArrivee;
                
                covoiturage.HeureDArrivee = HeureDArrivee;
                
                covoiturage.Prix = Prix;
                covoiturage.Description = Description;
                covoiturage.ServiceId = ServiceId;
                covoiturage.VehiculeId = VehiculeId;

                covoiturage.UtilisateurId = UtilisateurId;



                _bddContext.SaveChanges();
            }
        }

        public void ModifierCovoiturage(Covoiturage covoiturage)
        {
            _bddContext.Covoiturages.Update(covoiturage);
          
            _bddContext.SaveChanges();
        }
        //Supprimer
        public void SupprimerCovoiturage(int id)
        {
            Covoiturage covoiturage = _bddContext.Covoiturages.Find(id);

            if (covoiturage != null)
            {
                _bddContext.Covoiturages.Remove(covoiturage);
                _bddContext.SaveChanges();
            }
        }



        //*****************************Gestion des locations*********************************************//
        public List<Location> ObtientTousLesLocations()
        {
            return _bddContext.Locations.Include(s => s.Service).Include(v => v.Vehicule).Include(u=>u.Utilisateur).ToList();

        }
        public Location ObtenirLocation(int id)
        {
            return this._bddContext.Locations.FirstOrDefault(s => s.Id == id);
        }
        //Ajouter
        public int AjouterLocation(DateTime Disponible, string LieuDeDepot, double PrixParJour, string Description,  int ServiceId, int VehiculeId, int UtilisateurId, string Etat)
        {
            Location location = new Location()
            {
                Disponible = Disponible,
                LieuDeDepot = LieuDeDepot,
                PrixParJour = PrixParJour,
                
                Description = Description,
                Etat = Etat,

                ServiceId = ServiceId,
                VehiculeId = VehiculeId,
                UtilisateurId = UtilisateurId,


            };

            _bddContext.Locations.Add(location);
            _bddContext.SaveChanges();

            return location.Id;

        }
        public void AjouterLocation(Location location)
        {
            _bddContext.Locations.Update(location);
            _bddContext.SaveChanges();
        }



        //Modifier
        public void ModifierLocation(int Id, DateTime Disponible, string LieuDeDepot, double PrixParJour, string Description, int ServiceId, int VehiculeId, int UtilisateurId, string Etat)
        {
            Location location = _bddContext.Locations.Find(Id);

            if (location != null)
            {
                location.Disponible = Disponible;
                location.LieuDeDepot = LieuDeDepot;
                location.PrixParJour = PrixParJour;

                location.Etat = Etat;

                //location.Etat = "En attente";

                location.Description = Description;
                location.VehiculeId = VehiculeId;
                location.ServiceId = ServiceId;
                location.UtilisateurId = UtilisateurId;


                _bddContext.SaveChanges();
            }
        }
        public void ModifierLocation(Location location)
        {
            _bddContext.Locations.Update(location);
            _bddContext.SaveChanges();
        }
        //Supprimer
        public void SupprimerLocation(int id)
        {
            Location location = _bddContext.Locations.Find(id);

            if (location != null)
            {
                _bddContext.Locations.Remove(location);
                _bddContext.SaveChanges();
            }
        }




        //*****************************Gestion livraison colis*********************************************//


        public List<Colis> ObtientTousLesColis()
        {
            return _bddContext.LesColis.Include(s => s.Service).Include(u => u.Utilisateur).ToList();
           

        }
        public Colis ObtenirColis(int id)
        {
            return this._bddContext.LesColis.FirstOrDefault(c => c.Id == id);
        
        }

        //Ajouter

        public int AjouterColis(DateTime DateDeCreation,int Poids, string LieuDeCollecte, DateTime DateDeCollecte, string HeureDeCollecte, string LieuDeLivraison, string HeureDeLivraison, double Prix, string Description, int ServiceId, int UtilisateurId, string TailleColis, string Etat)
        {
            Colis colis = new Colis()
            {
                DateDeCreation= DateDeCreation,
                Poids =Poids,
                LieuDeCollecte=LieuDeCollecte,
                DateDeCollecte=DateDeCollecte,
                HeureDeCollecte=HeureDeCollecte,
                LieuDeLivraison=LieuDeLivraison,
                HeureDeLivraison= HeureDeLivraison,
                Prix=Prix,
                Description=Description,
                ServiceId = ServiceId,
                TailleColis = TailleColis,
                UtilisateurId = UtilisateurId,
                Etat = Etat,

            };


            _bddContext.LesColis.Add(colis);
            _bddContext.SaveChanges();

            return colis.Id;
        }


        //Modifier
        public void ModifierColis(int Id, int Poids, string LieuDeCollecte, DateTime DateDeCollecte, string HeureDeCollecte, string LieuDeLivraison, string HeureDeLivraison, double Prix, string Description, int ServiceId,  int UtilisateurId, string TailleColis, string Etat)
        {
            Colis colis = _bddContext.LesColis.Find(Id);

            if (colis != null)
            {
                colis.Poids = Poids;
                colis.LieuDeCollecte = LieuDeCollecte;
                colis.DateDeCollecte = DateDeCollecte;
                colis.HeureDeCollecte = HeureDeCollecte;
                colis.LieuDeLivraison = LieuDeLivraison;
                colis.HeureDeLivraison = HeureDeLivraison;
                colis.Prix = Prix;
                colis.Description = Description;
                colis.ServiceId = ServiceId;
                colis.TailleColis = TailleColis;
                colis.UtilisateurId = UtilisateurId;
                colis.Etat = Etat;


                _bddContext.SaveChanges();
            }
        }
        public void ModifierColis(Colis colis )
        {
            _bddContext.LesColis.Update(colis);
            _bddContext.SaveChanges();
        }
        //Supprimer
        public void SupprimerColis(int id)
        {
            Colis colis = _bddContext.LesColis.Find(id);

            if (colis!= null)
            {
                _bddContext.LesColis.Remove(colis);
                _bddContext.SaveChanges();
            }
        }





    }
}
