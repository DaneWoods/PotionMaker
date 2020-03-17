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
            return View("Index");
        }

        [HttpGet]
        public IActionResult PotionBrewing()
        {
            // Keep studying the ViewModels
            PotionCreationViewModel pcvm = new PotionCreationViewModel();
            pcvm.IngList = repo.Ingredients;
            return View(pcvm);
        }

        [HttpPost]
        public IActionResult PotionBrewing(PotionCreationViewModel pcvm)
        {
            Ingredient i1 = repo.getIngredientByID(pcvm.RIng1ID);
            Ingredient i2 = repo.getIngredientByID(pcvm.RIng2ID);
            Ingredient i3 = repo.getIngredientByID(pcvm.RIng3ID);
            Potion p = repo.potionMakingLogic(i1, i2, i3);
            if(p.CustomPotion == true)
            {
                return RedirectToAction("CustomPotion");
            }
            return RedirectToAction("PotionStock", repo.Ingredients);
        }

        [HttpGet]
        public IActionResult MerchantShop()
        {
            MerchantShopViewModel msvm = new MerchantShopViewModel();
            msvm.IngList = repo.Ingredients;
            return View(msvm);
        }

        [HttpPost]
        public IActionResult MerchantShop(MerchantShopViewModel msvn)
        {

            return View("MerchantShop", repo.Ingredients);
        }

        public IActionResult PotionStock()
        {
            return View(repo.Ingredients);
        }

        public IActionResult RecipeList()
        {
            return View(repo.Recipes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
