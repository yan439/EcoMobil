// Houda, Hamid, Yannick

using EcoMobil.Models.ManagementService;
using EcoMobil.Models.Personne;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using EcoMobil.Models.Comptabilite;

namespace EcoMobil.Models.BDD
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public DbSet<Vehicule> Vehicules { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Don> Dons { get; set; }

        public DbSet<Justificatif> Justificatifs { get; set; }

        public DbSet<Covoiturage> Covoiturages { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Colis> LesColis { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Paie> Paies { get; set; }

        public DbSet<Compte> Comptes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (System.Diagnostics.Debugger.IsAttached)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=EcoMobil");
            }
            else
            {
                IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specification on configuration

            //Declare non nullable columns
            modelBuilder.Entity<Utilisateur>().Property(u => u.Email).IsRequired();
            //Add uniqueness constraint
            modelBuilder.Entity<Utilisateur>().HasIndex(u => u.Email).IsUnique();
        }

        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Utilisateurs.AddRange(
                new Utilisateur
                {
                    Id = 1,
                    Nom = "Le Boss",
                    Prenom = "Admin",
                    Telephone = "0123628319",
                    Email = "admin@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Adhérent",
                    Role = Role.Admin


                },
                new Utilisateur
                {
                    Id = 2,
                    Nom = "Lagard",
                    Prenom = "Luc",
                    Telephone = "0620285107",
                    Email = "Lagard@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Adhérent",
                    Role = Role.ReadWrite

                },
                new Utilisateur
                {
                    Id = 3,
                    Nom = "Perez",
                    Prenom = "Véronique",
                    Telephone = "0629705135",
                    Email = "Perez@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Non adhérent",
                    Role = Role.ReadWrite
                },
                 new Utilisateur
                 {
                     Id = 4,
                     Nom = "Bruneau",
                     Prenom = "Thierry",
                     Telephone = "0614814221",
                     Email = "Thierry4@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }, new Utilisateur
                 {
                     Id = 5,
                     Nom = "Sourigues",
                     Prenom = "Yannick",
                     Telephone = "0623191635",
                     Email = "yannicksourigues@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }, new Utilisateur
                 {
                     Id = 6,
                     Nom = "Vallet",
                     Prenom = "Lucas-Benoît",
                     Telephone = "0651330548",
                     Email = "Vallet6@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 },
                 new Utilisateur
                 {
                     Id = 7,
                     Nom = "Gautier",
                     Prenom = "Maurice",
                     Telephone = "0697115004",
                     Email = "Gautier7@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 },
                new Utilisateur
                {
                    Id = 8,
                    Nom = "Lefebvre",
                    Prenom = "David",
                    Telephone = "0670013675",
                    Email = "Lefebvre8@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Adhérent",
                    Role = Role.ReadWrite
                },
                new Utilisateur
                {
                    Id = 9,
                    Nom = "Gilbert",
                    Prenom = "Vincent",
                    Telephone = "0662446791",
                    Email = "Gilbert9@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Non adhérent",
                    Role = Role.ReadWrite
                },
                 new Utilisateur
                 {
                     Id = 10,
                     Nom = "Mallet",
                     Prenom = "Maryse-Isabelle",
                     Telephone = "0657538188",
                     Email = "Mallet10@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }, new Utilisateur
                 {
                     Id = 11,
                     Nom = "Blin",
                     Prenom = "Louise",
                     Telephone = "0694513436",
                     Email = "Blin11@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }, new Utilisateur
                 {
                     Id = 12,
                     Nom = "Chauveau",
                     Prenom = "Gérard",
                     Telephone = "0601733843",
                     Email = "Chauveau12@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 },
                   new Utilisateur
                   {
                       Id = 13,
                       Nom = "Auger",
                       Prenom = "André",
                       Telephone = "0683205008",
                       Email = "Auger13@gmail.com",
                       MotDePasse = "Yan439!!",
                       Statut = "Adhérent",
                       Role = Role.ReadWrite
                   },
                new Utilisateur
                {
                    Id = 14,
                    Nom = "Etienne",
                    Prenom = "Aimée",
                    Telephone = "0680894126",
                    Email = "Etienne14@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Adhérent",
                    Role = Role.ReadWrite
                },
                new Utilisateur
                {
                    Id = 15,
                    Nom = "Albert",
                    Prenom = "Olivie",
                    Telephone = "0623180379",
                    Email = "Albert15@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Non adhérent",
                    Role = Role.ReadWrite
                },
                 new Utilisateur
                 {
                     Id = 16,
                     Nom = "Alves",
                     Prenom = "Emmanuel",
                     Telephone = "0672122128",
                     Email = "Alves16@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }, new Utilisateur
                 {
                     Id = 17,
                     Nom = "Allard",
                     Prenom = "Adrien",
                     Telephone = "0682847032",
                     Email = "Allard17@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }, new Utilisateur
                 {
                     Id = 18,
                     Nom = "Oliveira",
                     Prenom = "Aurore",
                     Telephone = "0618203572",
                     Email = "Oliveira18@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 },
                 new Utilisateur
                 {
                     Id = 19,
                     Nom = "Elise",
                     Prenom = "Antoinette",
                     Telephone = "0692495500",
                     Email = "Elise19@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 },
                new Utilisateur
                {
                    Id = 20,
                    Nom = "André",
                    Prenom = "Édouard",
                    Telephone = "0613832651",
                    Email = "André20@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Adhérent",
                    Role = Role.ReadWrite
                },
                new Utilisateur
                {
                    Id = 21,
                    Nom = "Escala",
                    Prenom = "Eugène",
                    Telephone = "0629705135",
                    Email = "Escala21@gmail.com",
                    MotDePasse = "Yan439!!",
                    Statut = "Non adhérent",
                    Role = Role.ReadWrite
                },
                 new Utilisateur
                 {
                     Id = 22,
                     Nom = "Antony",
                     Prenom = "Alex",
                     Telephone = "0658134853",
                     Email = "Antony22@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }, new Utilisateur
                 {
                     Id = 23,
                     Nom = "Armand",
                     Prenom = "Anaïs",
                     Telephone = "0600071020",
                     Email = "Armand23@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }, new Utilisateur
                 {
                     Id = 24,
                     Nom = "Izard",
                     Prenom = "Amélie",
                     Telephone = "0684816495",
                     Email = "Izard24@gmail.com",
                     MotDePasse = "Yan439!!",
                     Statut = "Adhérent",
                     Role = Role.ReadWrite
                 }
            );

            this.Justificatifs.AddRange(
                new Justificatif
                {
                    Id = 1,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = true,
                    Assurance = true,
                    ControleTechnique = true
                },
                new Justificatif
                {
                    Id = 2,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = true,
                    Assurance = true,
                    ControleTechnique = false
                },
                new Justificatif
                {
                    Id = 3,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = false,
                    Assurance = false,
                    ControleTechnique = true
                },
                 new Justificatif
                 {
                     Id = 4,
                     PermisDeConduire = true,
                     CertificatDImmatriculation = true,
                     Assurance = true,
                     ControleTechnique = true
                 },
                new Justificatif
                {
                    Id = 5,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = true,
                    Assurance = true,
                    ControleTechnique = false
                },
                new Justificatif
                {
                    Id = 6,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = false,
                    Assurance = false,
                    ControleTechnique = true
                },
                 new Justificatif
                 {
                     Id = 7,
                     PermisDeConduire = true,
                     CertificatDImmatriculation = true,
                     Assurance = true,
                     ControleTechnique = true
                 },
                new Justificatif
                {
                    Id = 8,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = true,
                    Assurance = true,
                    ControleTechnique = false
                },
                new Justificatif
                {
                    Id = 9,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = false,
                    Assurance = false,
                    ControleTechnique = true
                },
                 new Justificatif
                 {
                     Id = 10,
                     PermisDeConduire = true,
                     CertificatDImmatriculation = true,
                     Assurance = true,
                     ControleTechnique = true
                 },
                new Justificatif
                {
                    Id = 11,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = true,
                    Assurance = true,
                    ControleTechnique = false
                },
                new Justificatif
                {
                    Id = 12,
                    PermisDeConduire = true,
                    CertificatDImmatriculation = false,
                    Assurance = false,
                    ControleTechnique = true
                }
            );


            this.Services.AddRange(
                new Service
                {
                    Id = 1,
                    TypeService = "Covoiturage"

                },
                new Service
                {
                    Id = 2,

                    TypeService = "Location"

                },
                new Service
                {
                    Id = 3,

                    TypeService = "Livraison"

                }
            );



            this.Vehicules.AddRange(
                new Vehicule
                {
                    Id = 1,
                    Marque = "Citroen",
                    Modele = "C3 Aircross",
                    Automatique = true,
                    Electrique = false,
                    nombreDePortes = 5,
                    ControleTechnique = new DateTime(2023, 05, 10),
                    ImagePath = "/images/covoiturage/CitroenC3.jpg"




                },
                new Vehicule
                {
                    Id = 2,
                    Marque = "Tesla",
                    Modele = "Model S",
                    Automatique = true,
                    Electrique = true,
                    nombreDePortes = 5,
                    ControleTechnique = new DateTime(2025, 05, 10),
                    ImagePath = "/images/covoiturage/TeslaS.jpg"
                    //JustificatifId = 2,



                },
                new Vehicule
                {
                    Id = 3,
                    Marque = "Audi",
                    Modele = " A1",
                    Automatique = false,
                    Electrique = false,
                    nombreDePortes = 3,
                    ControleTechnique = new DateTime(2023, 01, 05),
                    ImagePath = "/images/covoiturage/audi.jpg"
                    //JustificatifId = 3

                },
                new Vehicule
                {
                    Id = 4,
                    Marque = "Renault",
                    Modele = "Clio 4",
                    Automatique = false,
                    Electrique = false,
                    nombreDePortes = 5,
                    ControleTechnique = new DateTime(2023, 08, 10),
                    ImagePath = "/images/covoiturage/Clio4.jpg"
                    //JustificatifId = 1,


                },
                new Vehicule
                {
                    Id = 5,
                    Marque = "Volkswagen",
                    Modele = "ID3",
                    Automatique = true,
                    Electrique = true,
                    nombreDePortes = 5,
                    ControleTechnique = new DateTime(2025, 06, 12),
                    ImagePath = "/images/covoiturage/VolkswagenID3.jpg"
                    //JustificatifId = 2,
                },
                new Vehicule
                {
                    Id = 6,
                    Marque = "BMW",
                    Modele = " Serie 5",
                    Automatique = false,
                    Electrique = false,
                    nombreDePortes = 3,
                    ControleTechnique = new DateTime(2023, 01, 05),
                    ImagePath = "/images/covoiturage/BMWSerie5.jpg"
                    //JustificatifId = 3

                },
                new Vehicule
                {
                    Id = 7,
                    Marque = "Mercedes",
                    Modele = "Viano ",
                    Automatique = false,
                    Electrique = false,
                    nombreDePortes = 5,
                    ControleTechnique = new DateTime(2023, 10, 10),
                    ImagePath = "/images/covoiturage/MercedesViano.jpg"
                    //JustificatifId = 1,


                },
                new Vehicule
                {
                    Id = 8,
                    Marque = "Ford",
                    Modele = "Focus",
                    Automatique = true,
                    Electrique = false,
                    nombreDePortes = 5,
                    ControleTechnique = new DateTime(2025, 09, 10),
                    ImagePath = "/images/covoiturage/FordFocus.gif"
                    //JustificatifId = 2,
                },
                new Vehicule
                {
                    Id = 9,
                    Marque = "Fiat",
                    Modele = " 500 e",
                    Automatique = true,
                    Electrique = true,
                    nombreDePortes = 3,
                    ControleTechnique = new DateTime(2023, 01, 05),
                    ImagePath = "/images/covoiturage/Fiat500e.jpg"
                    //JustificatifId = 3

                },
                new Vehicule
                {
                    Id = 10,
                    Marque = "Hyundai",
                    Modele = "Kona",
                    Automatique = true,
                    Electrique = true,
                    nombreDePortes = 5,
                    ControleTechnique = new DateTime(2023, 02, 10),
                    ImagePath = "/images/covoiturage/HyundaiKona.jpg"
                    //JustificatifId = 1,


                },
                new Vehicule
                {
                    Id = 11,
                    Marque = "Renault",
                    Modele = "Twingo 3",
                    Automatique = true,
                    Electrique = false,
                    nombreDePortes = 5,
                    ControleTechnique = new DateTime(2024, 05, 10),
                    ImagePath = "/images/covoiturage/RenaultTwingo3.jpg"
                    //JustificatifId = 2,
                },
                new Vehicule
                {
                    Id = 12,
                    Marque = "Peugeot",
                    Modele = "108",
                    Automatique = false,
                    Electrique = false,
                    nombreDePortes = 3,
                    ControleTechnique = new DateTime(2023, 11, 05),
                    ImagePath = "/images/covoiturage/Peugeot108.jpg"
                    //JustificatifId = 3

                },
                   new Vehicule
                   {
                       Id = 13,
                       Marque = "Renault",
                       Modele = "Twingo 3",
                       Automatique = true,
                       Electrique = false,
                       nombreDePortes = 5,
                       ControleTechnique = new DateTime(2024, 05, 10),
                       ImagePath = "/images/covoiturage/RenaultTwingo3.jpg"
                       //JustificatifId = 2,
                   },
                new Vehicule
                {
                    Id = 14,
                    Marque = "Peugeot",
                    Modele = "108",
                    Automatique = false,
                    Electrique = false,
                    nombreDePortes = 3,
                    ControleTechnique = new DateTime(2023, 11, 05),
                    ImagePath = "/images/covoiturage/Peugeot108.jpg"
                    //JustificatifId = 3

                }
                );


            this.Covoiturages.AddRange(
                new Covoiturage
                {
                    Id = 1,
                    DateDeCreation = DateTime.Now,
                    PlaceDisponible = 3,
                    Description = "je propose un covoiturage entre dax et Bordeaux  ",
                    LieuDeDepart = "Dax",
                    DateDeDepart = new DateTime(2022, 07, 23),
                    //DateDeDepart = (new DateTime(2022, 06, 10)).ToShortDateString(),
                    HeureDeDepart = "09:30",
                    LieuDArrivee = "Bordeaux",
                    HeureDArrivee = "11h",
                    Prix = 15,
                    Etat = "En attente",
                    ServiceId = 1,

                    VehiculeId = 4,
                    UtilisateurId = 4,
                    //JustificatifId = 4

                },
                new Covoiturage
                {
                    Id = 2,
                    DateDeCreation = new DateTime(2022, 06, 21),
                    PlaceDisponible = 2,

                    Description = "Je n'accepte pas les animaux ni les fumeurs",
                    LieuDeDepart = "Dax",
                    DateDeDepart = new DateTime(2022, 06, 21),
                    HeureDeDepart = "15:15",
                    LieuDArrivee = "La Rochelle",
                    HeureDArrivee = "19:00",

                    Prix = 15,

                    Etat = "Publié",

                    ServiceId = 1,

                    VehiculeId = 5,
                    UtilisateurId = 5,
                    //JustificatifId = 5

                },
              new Covoiturage
              {
                  Id = 3,
                  DateDeCreation = new DateTime(2022, 06, 15),
                  PlaceDisponible = 1,
                  Description = "trajet quoitidien pour passagers non fumeurs et ecolos dans une voiture eletrique ",
                  LieuDeDepart = "pau",
                  DateDeDepart = new DateTime(2022, 06, 22),
                  HeureDeDepart = "08:15",
                  LieuDArrivee = "Bordeaux",
                  HeureDArrivee = "10:15",
                  Prix = 15,
                  Etat = "En attente",
                  ServiceId = 1,

                  VehiculeId = 5,
                  UtilisateurId = 8,
                  // JustificatifId = 6
              },
               new Covoiturage
               {
                   Id = 4,
                   DateDeCreation = new DateTime(2022, 06, 18),
                   PlaceDisponible = 3,
                   Description = "Bonjour, je propose un covoiturage de Pau jusqu'a Bordeau le mercredi 22 juin Des arrêts sont possibles en cours de route si la ville est sur le chemin  ",
                   LieuDeDepart = "pau",
                   DateDeDepart = new DateTime(2022, 06, 22),
                   //DateDeDepart = (new DateTime(2022, 06, 10)).,
                   HeureDeDepart = "07:00",
                   LieuDArrivee = "Bordeaux",
                   HeureDArrivee = "09:15",
                   Prix = 15,
                   Etat = "En attente",
                   ServiceId = 1,
                   VehiculeId = 6,
                   UtilisateurId = 6,
                   // JustificatifId = 6
               },
                new Covoiturage
                {
                    Id = 5,
                    DateDeCreation = new DateTime(2022, 06, 02),
                    PlaceDisponible = 2,
                    Description = "Bonjour, Je retourne sur Paris ce jour en partant de . Je dispose de trois places ,Vous pouvez me contacter. N'hésitez pas à me laisser un message !Merci ",
                    LieuDeDepart = "Bordeau",
                    DateDeDepart = new DateTime(2022, 06, 23),
                    HeureDeDepart = "08:15",
                    LieuDArrivee = "Bayonne",
                    HeureDArrivee = "09:30",
                    Prix = 16,
                    Etat = "Publié",
                    ServiceId = 1,
                    VehiculeId = 7,
                    UtilisateurId = 7,
                    // JustificatifId = 7
                },
              new Covoiturage
              {
                  Id = 6,
                  DateDeCreation = new DateTime(2022, 06, 20),
                  PlaceDisponible = 3,
                  Description = "Je propose 3 places dans mon véhicule pour un trajet entre Montauban et Toulouse  hôtel de ville ou gare routière",
                  LieuDeDepart = "Montauban",
                  DateDeDepart = new DateTime(2022, 06, 22),
                  HeureDeDepart = "07:30",
                  LieuDArrivee = "Toulouse",
                  HeureDArrivee = "10:15",
                  Prix = 20,
                  Etat = "En attente",
                  ServiceId = 1,
                  VehiculeId = 8,
                  UtilisateurId = 8,
                  // JustificatifId = 8
              },
               new Covoiturage
               {
                   Id = 7,
                   DateDeCreation = DateTime.Now,
                   PlaceDisponible = 3,
                   Description = "Je propose 4 places dans mon véhicule pour un trajet Bordeaux la rochelle  via  autoroute A10 pour un départ le vendredi 24 Juin vers 6 h 15 hôtel de ville ou gare routière  ",
                   LieuDeDepart = "Bordeaux",
                   DateDeDepart = new DateTime(2022, 06, 24),
                   //DateDeDepart = (new DateTime(2022, 06, 10)).ToShortDateString(),
                   HeureDeDepart = "16:15",
                   LieuDArrivee = "La rochelle",
                   HeureDArrivee = "18:10",
                   Prix = 20,
                   Etat = "En attente",
                   ServiceId = 1,
                   VehiculeId = 9,
                   UtilisateurId = 9,
                   // JustificatifId = 9
               },

              new Covoiturage
              {
                  Id = 8,
                  DateDeCreation = new DateTime(2022, 06, 09),
                  PlaceDisponible = 1,
                  Description = "trajet quoitidien pour passagers non fumeurs et ecolos dans une voiture eletrique ",
                  LieuDeDepart = "pau",
                  DateDeDepart = new DateTime(2022, 06, 23),
                  HeureDeDepart = "08:15",
                  LieuDArrivee = "Bordeaux",
                  HeureDArrivee = "10:15",
                  Prix = 15,
                  Etat = "En attente",
                  ServiceId = 1,
                  VehiculeId = 10,
                  UtilisateurId = 10,
                  // JustificatifId = 10
              },
               new Covoiturage
               {
                   Id = 9,
                   DateDeCreation = DateTime.Now,
                   PlaceDisponible = 3,
                   Description = "je propose un covoiturage entre dax et Bordeaux  ",
                   LieuDeDepart = "dax",
                   DateDeDepart = new DateTime(2022, 06, 25),
                   //DateDeDepart = (new DateTime(2022, 06, 10)).ToShortDateString(),
                   HeureDeDepart = "09:30",
                   LieuDArrivee = "Bordeaux",
                   HeureDArrivee = "11:00",
                   Prix = 15,
                   Etat = "En attente",
                   ServiceId = 1,
                   VehiculeId = 4,
                   UtilisateurId = 4,
                   // JustificatifId = 4
               },
                new Covoiturage
                {
                    Id = 10,
                    DateDeCreation = new DateTime(2022, 06, 02),
                    PlaceDisponible = 2,
                    Description = "Bonjour je par de Montauban  pour déposer dans les entourage à des bon prix merci.Le vendredi 24/06 .Merci",
                    LieuDeDepart = "Montauban",
                    DateDeDepart = new DateTime(2022, 08, 10),
                    HeureDeDepart = "18:15",
                    LieuDArrivee = "Arcachon",
                    HeureDArrivee = "20:30",
                    Prix = 25,
                    Etat = "Publié",
                    ServiceId = 1,
                    VehiculeId = 11,
                    UtilisateurId = 11,
                    //  JustificatifId = 11
                },
              new Covoiturage
              {
                  Id = 11,
                  DateDeCreation = new DateTime(2022, 06, 09),
                  PlaceDisponible = 3,
                  Description = "Bonjour je propose un aller retour dax bayonne depart a 9:30 retour a 19:30 ",
                  LieuDeDepart = "Dax",
                  DateDeDepart = new DateTime(2022, 07, 22),
                  HeureDeDepart = "09:30",
                  LieuDArrivee = "Bayonne",
                  HeureDArrivee = "10:15",
                  Prix = 12,
                  Etat = "En attente",
                  ServiceId = 1,
                  VehiculeId = 12,
                  UtilisateurId = 12,
                  // JustificatifId = 12
              },
              new Covoiturage
              {
                  Id = 12,
                  DateDeCreation = new DateTime(2022, 06, 09),
                  PlaceDisponible = 2,
                  Description = "Bonjour je propose un aller retour dax bayonne depart a 9:30 retour a 19:30 ",
                  LieuDeDepart = "Bayonne",
                  DateDeDepart = new DateTime(2022, 07, 10),
                  HeureDeDepart = "19:30",
                  LieuDArrivee = "Dax",
                  HeureDArrivee = "20:15",
                  Prix = 12,
                  Etat = "Publié",
                  ServiceId = 1,
                  VehiculeId = 12,
                  UtilisateurId = 12,
                  // JustificatifId = 12

              }
            );

            this.Locations.AddRange(
                new Location
                {
                    Id = 1,
                    DateDeCreation = DateTime.Now,
                    Description = "je propose ma voiture pour une location, le nettoyage la véhicule est obligatoire pour une location d'une semaine et/ou plus, tous dégâts engendrent lors de la location c'est à votre charge",
                    LieuDeDepot = "dax",
                    Disponible = new DateTime(2022, 07, 10),
                    PrixParJour = 15,
                    Etat = "En attente",
                    ServiceId = 2,
                    VehiculeId = 13,
                    UtilisateurId = 2,
                    //JustificatifId = 4

                },
                 new Location
                 {
                     Id = 2,
                     DateDeCreation = DateTime.Now,
                     Description = "je propose ma voiture pour une location, le nettoyage la véhicule est obligatoire pour une location d'une semaine et/ou plus, tous dégâts engendrent lors de la location c'est à votre charge",
                     LieuDeDepot = "Rochelle",
                     Disponible = new DateTime(2021, 07, 10),
                     PrixParJour = 15,
                     Etat = "Publié",
                     ServiceId = 2,
                     VehiculeId = 10,
                     UtilisateurId = 10,
                     //JustificatifId = 4

                 }
            );

            this.LesColis.AddRange(
              new Colis
              {
                  Id = 1,
                  DateDeCreation = DateTime.Now,
                  Description = "je peux livrer vos colis entre Bordeaux et Bayonne ",
                  LieuDeCollecte = "Bordeaux",
                  DateDeCollecte = new DateTime(2022, 06, 23),
                  HeureDeCollecte = "08:15",
                  LieuDeLivraison = "Bayonne",
                  ServiceId = 3,
                  TailleColis = "Moyen",
                  UtilisateurId = 7,
                  Prix = 10,
                  HeureDeLivraison = "11:15"
              },
                new Colis
                {
                    Id = 2,
                    DateDeCreation = DateTime.Now,
                    Description = "je peux livrer vos colis entre Dax et Bayonne  ",
                    LieuDeCollecte = "Dax",
                    DateDeCollecte = new DateTime(2022, 06, 23),
                    HeureDeCollecte = "08:15",
                    HeureDeLivraison = "11:00",
                    LieuDeLivraison = "Bordeaux",
                    ServiceId = 3,
                    TailleColis = "Petit",
                    UtilisateurId = 4,
                    Prix = 7
                }
            );

            this.Comptes.AddRange(
              new Compte
              {
                  Id = 1,
                  IBAN = "FR76 3000 3035 4098 7654 3210 925",
                  Solde = 5236.5,
                  NumeroDeCarte = "5355 9012 1234 5678",
                  DateFinValidite = "10/23",
                  Cryptogramme = "456",
                  UtilisateurId = 1
              },
                new Compte
                {
                    Id = 2,
                    IBAN = "FR76 1254 8029 9898 7654 3210 917",
                    Solde = 73367.64,
                    NumeroDeCarte = "2671 4788 1234 4321",
                    DateFinValidite = "08/22",
                    Cryptogramme = "253",
                    UtilisateurId = 4
                },
                new Compte
                {
                    Id = 3,
                    IBAN = "FR76 3000 4028 3798 7654 3210 943",
                    Solde = 17637.57,
                    NumeroDeCarte = "4371 8862 3657 9842",
                    DateFinValidite = "09/23",
                    Cryptogramme = "654",
                    UtilisateurId = 5
                }
            );
            this.Messages.AddRange(
                 new Message
                 {
                     Id = 1,
                     Date = "20/06/2022",
                     Heure = "10:15",
                     Destinataire = "SOURIGUES Yannick",
                     ObjetDuMessage = "Urgent   ",
                     CorpsDuMessage = "Tu peux venir me chercher a Capbreton, c'est une heure de trajet de plus seulement :) Merci! ",
                     EtatCoteExpediteur = "Envoyé",
                     EtatCoteDestinataire = "Non lu",
                     UtilisateurId = 6
                 }
                 
             );
            this.Reservations.AddRange(
                 new Reservation
                 {
                     Id = 1,
                     Date = "20/06/2022",
                     Etat = "En attente",
                     CovoiturageId =2,
                     UtilisateurId = 6
                 }
                 );
            this.SaveChanges();

        }
    }
}