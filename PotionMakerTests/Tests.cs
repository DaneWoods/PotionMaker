using System;
using Xunit;
using PotionMaker.Models;
using PotionMaker.Controllers;
using PotionMaker.Repositories;
using PotionMaker.ViewModels;

namespace PotionMakerTests
{
    public class Tests
    {
        Potion p1;
        Potion p2;
        Potion p3;
        Ingredient i1;
        Ingredient i2;
        Ingredient i3;
        Recipe r1;
        Recipe r2;
        Recipe r3;
        HomeController home;
        FakeRepository frepo;
        PotionCreationViewModel pcvm;
        PotionStockViewModel psvm;
        RecipePotionViewModel rpvm;
        MerchantShopViewModel msvn;

        public Tests()
        {
            frepo = new FakeRepository();
            home = new HomeController(frepo);
            i1 = new Ingredient { IngID = 0, IngPicture = "nether.png", IngName = "NetherWart", IngDescription = "The basics of every potion.", IngStock = 250 };
            i2 = new Ingredient { IngID = 1, IngPicture = "sugar.png", IngName = "Sugar", IngDescription = "Sweet.", IngStock = 50 };
            i3 = new Ingredient { IngID = 2, IngPicture = "blaze.png", IngName = "Blaze Powder", IngDescription = "Hot to the touch.", IngStock = 50 };
            p1 = new Potion { PotionID = 0, PotionName = "Potion of Swiftness", PotionDescription = "Makes the user run with godspeed", PIng1 = i1, PIng2 = i2, PIng3 = i2, PotionStock = 1 };
            p2 = new Potion { PotionID = 1, PotionName = "Potion of Strength", PotionDescription = "Gives the strength of the mightiest warrior", PIng1 = i1, PIng2 = i3, PIng3 = i3, PotionStock = 1 };
            p3 = new Potion { PotionID = 2, PotionName = "Potion of Coolness", PotionDescription = "Makes you really cool", PIng1 = i1, PIng2 = i2, PIng3 = i3, PotionStock = 1 };
            r1 = new Recipe { RecipeID = 0, RPotionName = "Potion of Swiftness", RPotionDesc = "Makes the user run with godspeed", RIng1 = i1, RIng2 = i2, RIng3 = i2 };
            r2 = new Recipe { RecipeID = 1, RPotionName = "Potion of Strength", RPotionDesc = "Gives the strength of the mightiest warrior", RIng1 = i1, RIng2 = i3, RIng3 = i3 };
            r3 = new Recipe { RecipeID = 2, RPotionName = "Potion of Coolness", RPotionDesc = "Makes you really cool", RIng1 = i1, RIng2 = i2, RIng3 = i3};
            frepo.Ingredients.Add(i1);
            frepo.Ingredients.Add(i2);
            frepo.Ingredients.Add(i3);
            pcvm = new PotionCreationViewModel { Ingredients = frepo.Ingredients, Recipes = frepo.Recipes };
            psvm = new PotionStockViewModel { Ingredients = frepo.Ingredients, Potions = frepo.Potions };
            rpvm = new RecipePotionViewModel { Recipes = frepo.Recipes };
            msvn = new MerchantShopViewModel { IngList = frepo.Ingredients };
        }

        [Fact]
        public void PotionBrewingTestSuccess()
        {
            // Arrange
            pcvm.PotionName = p1.PotionName;
            pcvm.PotionDesc = p1.PotionDescription;
            pcvm.RIng1ID = i1.IngID;
            pcvm.RIng2ID = i2.IngID;
            pcvm.RIng3ID = i2.IngID;
            // Act
            home.PotionBrewing(pcvm);
            // Assert
            Assert.Equal(1, frepo.Potions.Count);
            Assert.Equal(1, frepo.Recipes.Count);
            Assert.Equal(p1.PotionName, frepo.Potions[0].PotionName);
            Assert.Equal(1, frepo.Potions[0].PotionStock);
            Assert.Equal(r1.RPotionName, frepo.Recipes[0].RPotionName);
            Assert.Equal(r1.RPotionDesc, frepo.Recipes[0].RPotionDesc);
            Assert.Equal(r1.RIng1, frepo.Recipes[0].RIng1);
            Assert.Equal(r1.RIng2, frepo.Recipes[0].RIng2);
            Assert.Equal(r1.RIng3, frepo.Recipes[0].RIng3);
        }

        [Fact]
        public void PotionBrewingTestFailure()
        {
            // Arrange
            pcvm.PotionName = p1.PotionName;
            pcvm.PotionDesc = p1.PotionDescription;
            i2.IngStock = 1;
            pcvm.RIng1ID = i1.IngID;
            pcvm.RIng2ID = i2.IngID;
            pcvm.RIng3ID = i2.IngID;
            // Act
            home.PotionBrewing(pcvm);
            // Assert
            Assert.Equal(0, frepo.Potions.Count);
            Assert.Equal(0, frepo.Recipes.Count);
            Assert.True(pcvm.outOfStock);
        }

        [Fact]
        public void RecipeBrewingTestSuccess()
        {
            // Arrange
            pcvm.Recipes.Add(r1);
            pcvm.RecipeID = 0;
            // Act
            home.RecipeBrewing(pcvm);
            // Assert
            Assert.Equal(1, frepo.Potions.Count);
            Assert.Equal(1, frepo.Recipes.Count);
            Assert.Equal(p1.PotionName, frepo.Potions[0].PotionName);
            Assert.Equal(1, frepo.Potions[0].PotionStock);
            Assert.Equal(r1.RPotionName, frepo.Recipes[0].RPotionName);
            Assert.Equal(r1.RPotionDesc, frepo.Recipes[0].RPotionDesc);
            Assert.Equal(r1.RIng1, frepo.Recipes[0].RIng1);
            Assert.Equal(r1.RIng2, frepo.Recipes[0].RIng2);
            Assert.Equal(r1.RIng3, frepo.Recipes[0].RIng3);
        }

        [Fact]
        public void RecipeBrewingTestFailure()
        {
            // Arrange
            frepo.Ingredients[1].IngStock = 1;
            pcvm.Recipes.Add(r1);
            pcvm.RecipeID = 0;
            // Act
            home.RecipeBrewing(pcvm);
            // Assert
            Assert.Equal(0, frepo.Potions.Count);
            Assert.Equal(1, frepo.Recipes.Count);
            Assert.True(pcvm.outOfStock);
        }

        [Fact]
        public void MerchantShopTestSuccess()
        {
            // Arrange
            msvn.IngredientID = 0;
            msvn.AmountBought = 50;
            // Act
            home.MerchantShop(msvn);
            // Assert
            Assert.Equal(300, frepo.Ingredients[0].IngStock);
        }
    }
}
