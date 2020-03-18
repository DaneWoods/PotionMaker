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
                Ingredient nether = new Ingredient { IngPicture="nether.png", IngName = "NetherWart", IngDescription = "The basics of every potion.", IngStock = 250 };
                Ingredient puff = new Ingredient { IngPicture = "puff.png", IngName = "Pufferfish", IngDescription = "Ouch! pointy.", IngStock = 50 };
                Ingredient sugar = new Ingredient { IngPicture = "sugar.png", IngName = "Sugar", IngDescription = "Sweet.", IngStock = 50 };
                Ingredient rabbit = new Ingredient { IngPicture = "rabbit.png", IngName = "Rabbit's Foot", IngDescription = "Very lucky.", IngStock = 50 };
                Ingredient blaze = new Ingredient { IngPicture = "blaze.png", IngName = "Blaze Powder", IngDescription = "Hot to the touch.", IngStock = 50 };
                Ingredient glistering = new Ingredient { IngPicture = "glistering.png", IngName = "Glistering Melon", IngDescription = "I don't think you can eat this.", IngStock = 50 };
                Ingredient spider = new Ingredient { IngPicture = "spider.png", IngName = "Spider Eye", IngDescription = "Very gross, and poisonous.", IngStock = 50 };
                Ingredient ghast = new Ingredient { IngPicture = "ghast.png", IngName = "Ghast Tear", IngDescription = "Aww so sad.", IngStock = 50 };
                Ingredient magma = new Ingredient { IngPicture = "magma.png", IngName = "Magma Cream", IngDescription = "Too slimy", IngStock = 50 };
                Ingredient golden = new Ingredient { IngPicture = "golden.png", IngName = "Golden Carrot", IngDescription = "Maximum sight.", IngStock = 50 };
                Ingredient turtle = new Ingredient { IngPicture = "turtle.png", IngName = "Turtle Shell", IngDescription = "Large and very heavy.", IngStock = 50 };
                Ingredient phantom = new Ingredient { IngPicture = "phantom.png", IngName = "Phantom Membrane", IngDescription = "Where did I even get this.", IngStock = 50 };
                Ingredient red = new Ingredient { IngPicture = "red.png", IngName = "Red Stone", IngDescription = "Power in the palm of my hand.", IngStock = 50 };
                Ingredient glow = new Ingredient { IngPicture = "glow.png", IngName = "Glow Stone", IngDescription = "Glows bright like the sun.", IngStock = 50 };
            if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange( puff, sugar, rabbit, blaze, glistering, spider, ghast, magma, golden, turtle, phantom, red, glow);
                context.SaveChanges();
            }
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe { RPotionName = "Potion of Swiftness", RPotionDesc = "Makes the user run with godspeed", RIng1 = nether, RIng2 = sugar, RIng3 = sugar },
                    new Recipe { RPotionName = "Potion of Leaping", RPotionDesc = "Jump over mountains in a single bound.", RIng1 = nether, RIng2 = rabbit, RIng3 = rabbit },
                    new Recipe { RPotionName = "Potion of Strength", RPotionDesc = "Gives the strength of the mightiest warrior", RIng1 = nether, RIng2 = blaze, RIng3 = blaze },
                    new Recipe { RPotionName = "Potion of Healing", RPotionDesc = "Heals the user instantly", RIng1 = nether, RIng2 = glistering, RIng3 = glistering },
                    new Recipe { RPotionName = "Potion of Poison", RPotionDesc = "Dont drink this at any cost, it will hurt you.", RIng1 = nether, RIng2 = spider, RIng3 = spider },
                    new Recipe { RPotionName = "Potion of Regeneration", RPotionDesc = "Heals the user over a curtain amount of time", RIng1 = nether, RIng2 = ghast, RIng3 = ghast },
                    new Recipe { RPotionName = "Potion of Fire Resistance", RPotionDesc = "Immune to increadibly high tempuratures and fire in general.", RIng1 = nether, RIng2 = magma, RIng3 = magma },
                    new Recipe { RPotionName = "Potion of Water Breathing", RPotionDesc = "Allows the user to breath under water", RIng1 = nether, RIng2 = puff, RIng3 = puff },
                    new Recipe { RPotionName = "Potion of Night Vision", RPotionDesc = "Midnight will look like it is noon", RIng1 = nether, RIng2 = golden, RIng3 = golden },
                    new Recipe { RPotionName = "Potion of Turtle Master", RPotionDesc = "You may move slow but your strength is second to none", RIng1 = nether, RIng2 = turtle, RIng3 = turtle },
                    new Recipe { RPotionName = "Potion of Slow Falling", RPotionDesc = "You gracefully float to the ground", RIng1 = nether, RIng2 = phantom, RIng3 = phantom }
                    );
                context.SaveChanges();
            }
            if (!context.Potions.Any())
            {
                context.Potions.AddRange(
                    new Potion { PotionName = "Potion of Swiftness", PotionDescription = "Makes the user run with godspeed", PIng1 = nether, PIng2 = sugar, PIng3 = sugar, PotionStock = 1},
                    new Potion { PotionName = "Potion of Leaping", PotionDescription = "Jump over mountains in a single bound.", PIng1 = nether, PIng2 = rabbit, PIng3 = rabbit, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Strength", PotionDescription = "Gives the strength of the mightiest warrior", PIng1 = nether, PIng2 = blaze, PIng3 = blaze, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Healing", PotionDescription = "Heals the user instantly", PIng1 = nether, PIng2 = glistering, PIng3 = glistering, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Poison", PotionDescription = "Dont drink this at any cost, it will hurt you.", PIng1 = nether, PIng2 = spider, PIng3 = spider, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Regeneration", PotionDescription = "Heals the user over a curtain amount of time", PIng1 = nether, PIng2 = ghast, PIng3 = ghast, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Fire Resistance", PotionDescription = "Immune to increadibly high tempuratures and fire in general.", PIng1 = nether, PIng2 = magma, PIng3 = magma, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Water Breathing", PotionDescription = "Allows the user to breath under water", PIng1 = nether, PIng2 = puff, PIng3 = puff, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Night Vision", PotionDescription = "Midnight will look like it is noon", PIng1 = nether, PIng2 = golden, PIng3 = golden, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Turtle Master", PotionDescription = "You may move slow but your strength is second to none", PIng1 = nether, PIng2 = turtle, PIng3 = turtle, PotionStock = 1 },
                    new Potion { PotionName = "Potion of Slow Falling", PotionDescription = "You gracefully float to the ground", PIng1 = nether, PIng2 = phantom, PIng3 = phantom, PotionStock = 1 }
                    );
                context.SaveChanges();
            }
        }
    }
}
