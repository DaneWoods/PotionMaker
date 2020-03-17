using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PotionMaker.Repositories
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .GetRequiredService<AppDbContext>();
                context.Database.Migrate();
                Ingredient nether = new Ingredient { IngName = "NetherWart", IngDescription = "The basics of every potion.", IngStock = 250 };
                Ingredient puff = new Ingredient { IngName = "Pufferfish", IngDescription = "Ouch! pointy.", IngStock = 50 };
                Ingredient sugar = new Ingredient { IngName = "Sugar", IngDescription = "Sweet.", IngStock = 50 };
                Ingredient rabbit = new Ingredient { IngName = "Rabbit's Foot", IngDescription = "Very lucky.", IngStock = 50 };
                Ingredient blaze = new Ingredient { IngName = "Blaze Powder", IngDescription = "Hot to the touch.", IngStock = 50 };
                Ingredient glistering = new Ingredient { IngName = "Glistering Melon", IngDescription = "I don't think you can eat this.", IngStock = 50 };
                Ingredient spider = new Ingredient { IngName = "Spider Eye", IngDescription = "Very gross, and poisonous.", IngStock = 50 };
                Ingredient ghast = new Ingredient { IngName = "Ghast Tear", IngDescription = "Aww so sad.", IngStock = 50 };
                Ingredient magma = new Ingredient { IngName = "Magma Cream", IngDescription = "Too slimy", IngStock = 50 };
                Ingredient golden = new Ingredient { IngName = "Golden Carrot", IngDescription = "Maximum sight.", IngStock = 50 };
                Ingredient turtle = new Ingredient { IngName = "Turtle Shell", IngDescription = "Large and very heavy.", IngStock = 50 };
                Ingredient phantom = new Ingredient { IngName = "Phantom Membrane", IngDescription = "Where did I even get this.", IngStock = 50 };
                Ingredient red = new Ingredient { IngName = "Red Stone", IngDescription = "Power in the palm of my hand.", IngStock = 50 };
                Ingredient glow = new Ingredient { IngName = "Glow Stone", IngDescription = "Glows bright like the sun.", IngStock = 50 };
            if (!context.Ingredients.Any())
            {
                

                context.Ingredients.AddRange( puff, sugar, rabbit, blaze, glistering, spider, ghast, magma, golden, turtle, phantom, red, glow);
                context.SaveChanges();
            }
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe { RPotionName = "Potion of Swiftness", RIng1 = nether, RIng2 = sugar, RIng3 = sugar },
                    new Recipe { RPotionName = "Potion of Leaping", RIng1 = nether, RIng2 = rabbit, RIng3 = rabbit },
                    new Recipe { RPotionName = "Potion of Strength", RIng1 = nether, RIng2 = blaze, RIng3 = blaze },
                    new Recipe { RPotionName = "Potion of Healing", RIng1 = nether, RIng2 = glistering, RIng3 = glistering },
                    new Recipe { RPotionName = "Potion of Poison", RIng1 = nether, RIng2 = spider, RIng3 = spider },
                    new Recipe { RPotionName = "Potion of Regeneration", RIng1 = nether, RIng2 = ghast, RIng3 = ghast },
                    new Recipe { RPotionName = "Potion of Fire Resistance", RIng1 = nether, RIng2 = magma, RIng3 = magma },
                    new Recipe { RPotionName = "Potion of Water Breathing", RIng1 = nether, RIng2 = puff, RIng3 = puff },
                    new Recipe { RPotionName = "Potion of Night Vision", RIng1 = nether, RIng2 = golden, RIng3 = golden },
                    new Recipe { RPotionName = "Potion of Turtle Master", RIng1 = nether, RIng2 = turtle, RIng3 = turtle },
                    new Recipe { RPotionName = "Potion of Slow Falling", RIng1 = nether, RIng2 = phantom, RIng3 = phantom }
                    );
                context.SaveChanges();
            }
        }
    }
}
