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

        //public bool potionNameExists(Potion p)
        //{
        //    bool nameExists = false;
        //    for (int i = 0; i < Recipes.Count; i++)
        //    {
        //        if(Recipes[i])
        //        {
        //            return nameExists = true;
        //        }
        //    }
        //    return nameExists;
        //}

        public bool potionExists(Potion p)
        {
            bool pExists = false;
            for(int i = 0; i < Potions.Count; i++)
            {
                if(Potions[i] == p)
                {
                    return pExists = true;
                }
            }
            return pExists;
        }
        public void incrementPotion(Potion p)
        {
            Potion cP = context.Potions.First(x => x == p);
            cP.PotionStock++;
            context.Update(cP);
            context.SaveChanges();
        }

        public void addIngredientStock(MerchantShopViewModel msvn)
        {
            Ingredient i = getIngredientByID(msvn.IngredientID);
            if (msvn.AmountBought >= 0 && msvn.AmountBought <= 100)
            {
                i.IngStock = i.IngStock + msvn.AmountBought;
                context.Ingredients.Update(i);
                context.SaveChanges();
            }
            else
                throw new ArgumentOutOfRangeException("Please input a value between 0 and 100");
            
        }

        public void minusIngredientStock(Recipe r)
        {
            Ingredient i1 = context.Ingredients.First(x => x.IngID == r.RIng1.IngID);
            Ingredient i2 = context.Ingredients.First(x => x.IngID == r.RIng2.IngID);
            Ingredient i3 = context.Ingredients.First(x => x.IngID == r.RIng3.IngID);
            i1.IngStock--;
            i2.IngStock--;
            i3.IngStock--;
            context.Ingredients.Update(i1);
            context.Ingredients.Update(i2);
            context.Ingredients.Update(i3);
            context.SaveChanges();
        }

        public void addIngredientRecipeStock(Recipe r)
        {
            Ingredient i1 = context.Ingredients.First(x => x.IngID == r.RIng1.IngID);
            Ingredient i2 = context.Ingredients.First(x => x.IngID == r.RIng2.IngID);
            Ingredient i3 = context.Ingredients.First(x => x.IngID == r.RIng3.IngID);
            i1.IngStock++;
            i2.IngStock++;
            i3.IngStock++;
            context.Ingredients.Update(i1);
            context.Ingredients.Update(i2);
            context.Ingredients.Update(i3);
            context.SaveChanges();
        }

        public Ingredient getIngredientByID(int id)
        {
            return context.Ingredients.First(x => x.IngID == id);
        }
        public Potion getPotionByID(int id)
        {
            return context.Potions.First(x => x.PotionID == id);
        }

        public Potion getPotionByName(string pName)
        {
            foreach(Potion po in context.Potions)
            {
                if(po.PotionName == pName)
                {
                    return po;
                }
            }
            return null;
        }

        public Recipe getRecipeByID(int id)
        {
            if(id != 0)
            {
                return context.Recipes.First(x => x.RecipeID == id);
            }
            return null;
            
        }

        public Recipe getRecipeByName(string pName)
        {
            foreach (Recipe r in context.Recipes)
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
            context.Potions.Remove(p);
            context.SaveChanges();
        }
        public void deleteRecipe(Recipe r)
        {
            context.Recipes.Remove(r);
            context.Potions.Remove(getPotionByName(r.RPotionName));
            context.SaveChanges();
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
