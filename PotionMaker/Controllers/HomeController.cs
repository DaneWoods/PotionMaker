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
            pcvm.Ingredients = repo.Ingredients;
            pcvm.Recipes = repo.Recipes;
            return View(pcvm);
        }

        [HttpPost]
        public IActionResult PotionBrewing(PotionCreationViewModel pcvm)
        {   
            pcvm.Ingredients = repo.Ingredients;
            pcvm.Recipes = repo.Recipes;
            if (ModelState.IsValid)
            {
                ViewBag.nameExists = false;
                
                Ingredient i1 = repo.getIngredientByID(pcvm.RIng1ID);
                Ingredient i2 = repo.getIngredientByID(pcvm.RIng2ID);
                Ingredient i3 = repo.getIngredientByID(pcvm.RIng3ID);
                Potion p = repo.getPotionByName(pcvm.PotionName);
                //Potion p = new Potion { PotionName = pcvm.PotionName, PotionDescription = pcvm.PotionDesc, PIng1 = i1, PIng2 = i2, PIng3 = i3 };
                PotionStockViewModel psvm = new PotionStockViewModel();
                psvm.Ingredients = repo.Ingredients;
                psvm.Potions = repo.Potions;
                if (p != null)
                {
                    Recipe rec = repo.getRecipeByName(p.PotionName);
                    if (i1 == rec.RIng1 && i2 == rec.RIng2 && i3 == rec.RIng3)
                    {
                        
                        repo.minusIngredientStock(rec);
                        if(i1.IngStock < 0 || i2.IngStock < 0 || i3.IngStock < 0)
                        {
                            repo.addIngredientRecipeStock(rec);
                            pcvm.outOfStock = true;
                            return View(pcvm);
                        }
                        else
                        {
                            repo.incrementPotion(p);
                            return RedirectToAction("PotionStock", psvm);
                        }
                    }
                    else
                    {
                        pcvm.Error = true;
                        return View(pcvm);
                    }
                }
                else
                {
                    Recipe r = repo.getRecipeByName(pcvm.PotionName);
                    if (r == null)
                    {
                        r = new Recipe { RPotionName = pcvm.PotionName, RIng1 = i1, RIng2 = i2, RIng3 = i3 };
                        p = new Potion
                        {
                            PotionName = pcvm.PotionName,
                            PotionDescription = pcvm.PotionDesc,
                            PIng1 = i1,
                            PIng2 = i2,
                            PIng3 = i3,
                            PotionStock = 1
                        };
                        repo.minusIngredientStock(r);
                        if (i1.IngStock < 0 || i2.IngStock < 0 || i3.IngStock < 0)
                        {
                            repo.addIngredientRecipeStock(r);
                            pcvm.outOfStock = true;
                            return View(pcvm);
                        }
                        repo.addPotion(p);
                        repo.addRecipe(r);
                        return RedirectToAction("PotionStock", psvm);
                    }
                    else
                    {
                        if (i1 == r.RIng1 && i2 == r.RIng2 && i3 == r.RIng3)
                        {
                            p = new Potion { PotionName = pcvm.PotionName, PotionDescription = pcvm.PotionDesc,
                                PIng1 = i1, PIng2 = i2, PIng3 = i3, PotionStock = 1};
                            repo.minusIngredientStock(r);
                            if (i1.IngStock < 0 || i2.IngStock < 0 || i3.IngStock < 0)
                            {
                                repo.addIngredientRecipeStock(r);
                                pcvm.outOfStock = true;
                                return View(pcvm);
                            }
                            repo.addPotion(p);
                            return RedirectToAction("PotionStock", psvm);
                        }
                        pcvm.Error = true;
                        return View(pcvm);
                    }
                }
            }
            return View(pcvm);
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
            repo.addIngredientStock(msvn);
            msvn.IngList = repo.Ingredients;
            return View(msvn);
        }

        public IActionResult PotionStock()
        {
            PotionStockViewModel psvm = new PotionStockViewModel();
            psvm.Ingredients = repo.Ingredients;
            psvm.Potions = repo.Potions;
            return View(psvm);
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
