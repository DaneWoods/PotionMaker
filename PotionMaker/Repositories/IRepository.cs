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
        //bool potionNameExists(Potion p);
        bool potionExists(Potion p);
        void incrementPotion(Potion p);
        void addIngredientStock(MerchantShopViewModel msvn);
        void addIngredientRecipeStock(Recipe r);
        void minusIngredientStock(Recipe r);
        Ingredient getIngredientByID(int id);
        Potion getPotionByID(int id);
        Potion getPotionByName(string pName);
        Recipe getRecipeByID(int id);
        Recipe getRecipeByName(string pName);
        void addPotion(Potion p);
        void addRecipe(Recipe r);
    }
}
