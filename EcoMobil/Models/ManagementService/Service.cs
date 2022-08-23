// Yannick

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoMobil.Models.ManagementService
{
    public class Service

    {
        public int Id { get; set; }

        //************************Attributs******************************//

        public string TypeService { get; set; }

        public enum ServiceType
        {
            Covoiturage,
            Location,
            Livraison,
        }


        //***********************clé secondaire*************************//


    }
}