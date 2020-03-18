using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;
using PotionMaker.ViewModels;

namespace PotionMaker.Repositories
{
    public class FakeRepository : IRepository
    {
        public static List<Potion> potions = new List<Potion>();
        public static List<Ingredient> ingredients = new List<Ingredient>();
        public static List<Recipe> recipes = new List<Recipe>();
        public static List<AppUser> appUsers = new List<AppUser>();

        public List<Potion> Potions { get { return potions; } }
        public List<Ingredient> Ingredients { get { return ingredients; } }
        public List<Recipe> Recipes { get { return recipes; } }
        public List<AppUser> Users { get { return appUsers; } }

        public bool potionExists(Potion p)
        {
            bool pExists = false;
            for (int i = 0; i < Potions.Count; i++)
            {
                if (Potions[i] == p)
                {
                    return pExists = true;
                }
            }
            return pExists;
        }
        public void incrementPotion(Potion p)
        {
            Potion cP = Potions.First(x => x == p);
            cP.PotionStock++;
        }

        public void addIngredientStock(MerchantShopViewModel msvn)
        {
            Ingredient i = getIngredientByID(msvn.IngredientID);
            if (msvn.AmountBought >= 0 && msvn.AmountBought <= 100)
            {
                i.IngStock = i.IngStock + msvn.AmountBought;
            }
            else
                throw new ArgumentOutOfRangeException("Input a number between 0 and 100");
        }

        public void minusIngredientStock(Recipe r)
        {
            Ingredient i1 = Ingredients.First(x => x.IngID == r.RIng1.IngID);
            Ingredient i2 = Ingredients.First(x => x.IngID == r.RIng2.IngID);
            Ingredient i3 = Ingredients.First(x => x.IngID == r.RIng3.IngID);
            i1.IngStock--;
            i2.IngStock--;
            i3.IngStock--;
        }

        public void addIngredientRecipeStock(Recipe r)
        {
            Ingredient i1 = Ingredients.First(x => x.IngID == r.RIng1.IngID);
            Ingredient i2 = Ingredients.First(x => x.IngID == r.RIng2.IngID);
            Ingredient i3 = Ingredients.First(x => x.IngID == r.RIng3.IngID);
            i1.IngStock++;
            i2.IngStock++;
            i3.IngStock++;
        }

        public Ingredient getIngredientByID(int id)
        {
            return Ingredients.First(x => x.IngID == id);
        }
        public Potion getPotionByID(int id)
        {
            return Potions.First(x => x.PotionID == id);
        }

        public Potion getPotionByName(string pName)
        {
            foreach (Potion po in Potions)
            {
                if (po.PotionName == pName)
                {
                    return po;
                }
            }
            return null;
        }

        public Recipe getRecipeByID(int id)
        {
            return Recipes.First(x => x.RecipeID == id);
        }

        public Recipe getRecipeByName(string pName)
        {
            foreach (Recipe r in Recipes)
            {
                if (r.RPotionName == pName)
                {
                    return r;
                }
            }
            return null;
        }

        public void deletePotion(Potion p)
        {
            Potions.Remove(p);
        }
        public void deleteRecipe(Recipe r)
        {
            Recipes.Remove(r);
            Potions.Remove(getPotionByName(r.RPotionName));
        }

        public void addPotion(Potion p)
        {
            Potions.Add(p);
        }

        public void addRecipe(Recipe r)
        {
            Recipes.Add(r);
        }
    }
}
