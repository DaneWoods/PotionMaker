using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;
using Microsoft.EntityFrameworkCore;
using PotionMaker.Repositories;

namespace PotionMaker.Repositories
{
    public class RealRepository : IRepository
    {
        public AppDbContext context;
        public List<Ingredient> Ingredients { get { return context.Ingredients.ToList(); } }
        public List<Potion> Potions { get { return context.Potions.ToList(); } }
        public List<Recipe> Recipes { get { return context.Recipes.ToList(); } }
        public RealRepository(AppDbContext dbContext)
        {
            context = dbContext;
        }
    }
}
