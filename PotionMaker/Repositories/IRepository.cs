using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.Repositories
{
    public interface IRepository
    {
        List<Ingredient> Ingredients { get; }
        List<Potion> Potions { get; }
        List<Recipe> Recipes { get; }
    }
}
