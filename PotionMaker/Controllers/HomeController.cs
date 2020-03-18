using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PotionMaker.Models;
using PotionMaker.Repositories;
using PotionMaker.ViewModels;
using Microsoft.AspNetCore.Identity;

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

        [Authorize(Roles = "Member,Admin")]
        [HttpGet]
        public IActionResult PotionBrewing()
        {
            // Keep studying the ViewModels
            PotionCreationViewModel pcvm = new PotionCreationViewModel();
            pcvm.Ingredients = repo.Ingredients;
            pcvm.Recipes = repo.Recipes;
            return View(pcvm);
        }

        [Authorize(Roles = "Member,Admin")]
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
                PotionStockViewModel psvm = new PotionStockViewModel();
                psvm.Ingredients = repo.Ingredients;
                psvm.Potions = repo.Potions;
                if (p != null)
                {
                    Recipe rec = repo.getRecipeByName(p.PotionName);
                    if (i1 == rec.RIng1 && i2 == rec.RIng2 && i3 == rec.RIng3)
                    {

                        repo.minusIngredientStock(rec);
                        if (i1.IngStock < 0 || i2.IngStock < 0 || i3.IngStock < 0)
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
                        r = new Recipe { RPotionName = pcvm.PotionName, RPotionDesc = pcvm.PotionDesc, RIng1 = i1, RIng2 = i2, RIng3 = i3 };
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
                            return RedirectToAction("PotionStock", psvm);
                        }
                        pcvm.Error = true;
                        return View(pcvm);
                    }
                }
            }
            return View(pcvm);
        }

        [Authorize(Roles = "Member,Admin")]
        [HttpGet]
        public IActionResult RecipeBrewing()
        {
            PotionRecipeCreationViewModel prcvm = new PotionRecipeCreationViewModel();
            prcvm.Recipes = repo.Recipes;
            return View(prcvm);
        }

        [Authorize(Roles = "Member,Admin")]
        [HttpPost]
        public IActionResult RecipeBrewing(PotionRecipeCreationViewModel prcvm)
        {
            prcvm.Recipes = repo.Recipes;
            if (ModelState.IsValid)
            {
                PotionStockViewModel psvm = new PotionStockViewModel();
                prcvm.Ingredients = repo.Ingredients;
                Recipe rec = repo.getRecipeByID(prcvm.RecipeID);
                Potion p = repo.getPotionByName(rec.RPotionName);
                if (p == null)
                {
                    p = new Potion { PotionName = rec.RPotionName, PotionDescription = rec.RPotionDesc, PIng1 = rec.RIng1, PIng2 = rec.RIng2, PIng3 = rec.RIng3, PotionStock = 1 };
                    repo.minusIngredientStock(rec);
                    if (rec.RIng1.IngStock < 0 || rec.RIng2.IngStock < 0 || rec.RIng3.IngStock < 0)
                    {
                        repo.addIngredientRecipeStock(rec);
                        prcvm.outOfStock = true;
                        return View(prcvm);
                    }
                    repo.addPotion(p);
                    psvm.Potions = repo.Potions;
                    psvm.Ingredients = repo.Ingredients;
                    return RedirectToAction("PotionStock", psvm);
                }
                repo.minusIngredientStock(rec);
                if (rec.RIng1.IngStock < 0 || rec.RIng2.IngStock < 0 || rec.RIng3.IngStock < 0)
                {
                    repo.addIngredientRecipeStock(rec);
                    prcvm.outOfStock = true;
                    return View(prcvm);
                }
                repo.incrementPotion(p);
                psvm.Potions = repo.Potions;
                psvm.Ingredients = repo.Ingredients;
                return RedirectToAction("PotionStock", psvm);
            }
            else
                return View(prcvm);
        }

        [Authorize(Roles = "Member,Admin")]
        [HttpGet]
        public IActionResult MerchantShop()
        {
            MerchantShopViewModel msvm = new MerchantShopViewModel();
            msvm.IngList = repo.Ingredients;
            return View(msvm);
        }

        [Authorize(Roles = "Member,Admin")]
        [HttpPost]
        public IActionResult MerchantShop(MerchantShopViewModel msvn)
        {
            msvn.IngList = repo.Ingredients;
            if (ModelState.IsValid)
            {
                repo.addIngredientStock(msvn);
                return View(msvn);
            }
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
            RecipePotionViewModel rpvm = new RecipePotionViewModel();
            rpvm.Recipes = repo.Recipes;
            return View(rpvm);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult RecipeDelete(RecipePotionViewModel rpvm)
        {
            repo.deleteRecipe(repo.getRecipeByID(rpvm.RecipeID));
            rpvm.Recipes = repo.Recipes;
            return View("RecipeList", rpvm);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult PotionDelete(PotionStockViewModel psvm)
        {
            repo.deletePotion(repo.getPotionByID(psvm.PotionID));
            psvm.Ingredients = repo.Ingredients;
            psvm.Potions = repo.Potions;
            return View("PotionStock", psvm);
        }

        [HttpGet]
        public IActionResult Searched(SearchViewModel svm)
        {
            svm.Potions = repo.Potions;
            svm.Recipes = repo.Recipes;
            svm.Ingredients = repo.Ingredients;
            return View(svm);
        }

        [HttpGet]
        public IActionResult Search()
        {
            SearchViewModel svm = new SearchViewModel();
            svm.Potions = repo.Potions;
            svm.Recipes = repo.Recipes;
            svm.Ingredients = repo.Ingredients;
            return View(svm);
        }
        public IActionResult IngredientSearch(SearchViewModel svm)
        {
            if (ModelState.IsValid)
            {
                svm.ingredientInID = svm.ingredientOutID;
                svm.Potions = repo.Potions;
                svm.Recipes = repo.Recipes;
                svm.Ingredients = repo.Ingredients;
                return RedirectToAction("Searched", svm);
            }
            return View(svm);
            
        }
        public IActionResult RecipeSearch(SearchViewModel svm)
        {
            if (ModelState.IsValid)
            {
                svm.recipeInID = svm.recipeOutID;
                svm.Potions = repo.Potions;
                svm.Recipes = repo.Recipes;
                svm.Ingredients = repo.Ingredients;
                return RedirectToAction("Searched", svm);
            }
            return View(svm);
        }
        public IActionResult PotionSearch(SearchViewModel svm)
        {
            if (ModelState.IsValid)
            {
                svm.potionInID = svm.potionOutID;
                svm.Potions = repo.Potions;
                svm.Recipes = repo.Recipes;
                svm.Ingredients = repo.Ingredients;
                return RedirectToAction("Searched", svm);
            }
            return View(svm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
