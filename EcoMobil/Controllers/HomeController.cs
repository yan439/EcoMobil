// Houda

using EcoMobil.Models;
using EcoMobil.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoMobil.Controllers
{
  
    public class HomeController : Controller
    {
     
       
            private DalUtilisateur dal;
            public HomeController()
            {
                dal = new DalUtilisateur();
            }
            public IActionResult Index()
            {
                return View();
            }
        }
    }
