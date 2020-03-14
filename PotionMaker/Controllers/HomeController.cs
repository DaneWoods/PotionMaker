using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PotionMaker.Models;
using PotionMaker.Repositories;
using PotionMaker.ViewModels;

namespace PotionMaker.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MerchantShop()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PotionBrewing()
        {
            PotionCreationViewModel pcvm = new PotionCreationViewModel();
            pcvm.IngList = repo.Ingredients;
            return View("PotionBrewing", pcvm);
        }

        [HttpPost]
        public IActionResult PotionBrewing()
        {
            return View("PotionBrewing", repo.);
        }

        public IActionResult PotionStock()
        {
            return View();
        }

        public IActionResult RecipeList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
