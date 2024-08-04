using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BonusVanillaStuff.Items.Tools
{
    public class EnchantedStopwatch : ModItem
    {
        public override void SetStaticDefaults() 
        {
            // DisplayName.SetDefault("Enchanted Stopwatch");
            // Tooltip.SetDefault("Changes night to day and day to night.  Enchanting!");
        }

    
        public override void SetDefaults()
        {
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = 4;
            Item.value = 10000;
            Item.rare = 4;
            Item.width = 34;
            Item.reuseDelay = 30;
            Item.height = 12;
            Item.noMelee = true;
        }
        
        public override bool? UseItem(Player player) {
            if(Main.dayTime) {
                Main.time = -1013;
                Main.dayTime = false;
            } else {
                Main.time = 7003;
                Main.dayTime = true;
            }
            return Main.dayTime;
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldWatch, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 7);
			recipe.AddIngredient(ItemID.SoulofNight, 7);
            recipe.AddIngredient(ItemID.CelestialStone);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

            Recipe recipe2 = CreateRecipe(); 
			recipe2.AddIngredient(ItemID.PlatinumWatch, 1);
			recipe2.AddIngredient(ItemID.SoulofLight, 7);
			recipe2.AddIngredient(ItemID.SoulofNight, 7);
            recipe2.AddIngredient(ItemID.CelestialStone);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.Register();
		}

    }
}