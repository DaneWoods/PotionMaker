using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;
using PotionMaker.ViewModels;

namespace PotionMaker.Repositories
{
    public interface IRepository
    {
        List<Ingredient> Ingredients { get; }
        List<Potion> Potions { get; }
        List<Recipe> Recipes { get; }
        Potion potionMakingLogic(Ingredient RIng1, Ingredient RIng2, Ingredient RIng3);
        void addIngredientStock(MerchantShopViewModel msvn);
        Ingredient getIngredientByID(int id);
        Potion getPotionByID(int id);
        Recipe getRecipeByID(int id);
        void addPotion(Potion p);
        void addRecipe(Recipe r);
    }
}
