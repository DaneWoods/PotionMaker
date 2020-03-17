using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;
using Microsoft.EntityFrameworkCore;
using PotionMaker.Repositories;
using PotionMaker.ViewModels;

namespace PotionMaker.Repositories
{
    public class RealRepository : IRepository
    {
        public AppDbContext context;
        public List<Ingredient> Ingredients { get { return context.Ingredients.ToList(); } }
        public List<Potion> Potions { get { return context.Potions.ToList(); } }
        public List<Recipe> Recipes { get { return context.Recipes.Include(x => x.RIng1).Include(x => x.RIng2).Include(x => x.RIng3).ToList(); } }
        public RealRepository(AppDbContext dbContext)
        {
            context = dbContext;
        }

        public Potion potionMakingLogic(Ingredient RIng1, Ingredient RIng2, Ingredient RIng3)
        {
            Potion p = new Potion();
            p.CustomPotion = false;
            p.PotionStock = 0;
            for(int i = 0; i < Recipes.Count; i++)
            {
                if(Recipes[i].RIng1 == RIng1 && Recipes[i].RIng2 == RIng2 && Recipes[i].RIng3 == RIng3)
                {
                    p.PotionName = Recipes[i].RPotionName;
                    p.PotionDescription = Recipes[i].RPotionDesc;
                    p.PotionStock++;
                    return p;
                }
            }
            p.CustomPotion = true;
            return p;
        }

        public void addIngredientStock(MerchantShopViewModel msvn)
        {
            Ingredient i = getIngredientByID(msvn.IngredientID);
            i.IngStock = i.IngStock + msvn.AmountBought;
            context.Ingredients.Update(i);
        }

        public Ingredient getIngredientByID(int id)
        {
            return context.Ingredients.First(x => x.IngID == id);
        }
        public Potion getPotionByID(int id)
        {
            return context.Potions.First(x => x.PotionID == id);
        }
        public Recipe getRecipeByID(int id)
        {
            return context.Recipes.First(x => x.RecipeID == id);
        }

        public void addPotion(Potion p)
        {
            context.Potions.Add(p);
            context.SaveChanges();
        }

        public void addRecipe(Recipe r)
        {
            context.Recipes.Add(r);
            context.SaveChanges();
        }
    }
}
