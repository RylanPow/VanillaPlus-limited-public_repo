using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace BonusVanillaStuff.Items.Weapons {
    
    public class Autostynger : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("66.6% chance to not consume ammo");
		}

       	public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Stynger);                       
			Item.DamageType = DamageClass.Ranged;     
			Item.damage = 110;                  
			Item.width = 40;                          
			Item.height = 20;                         
			Item.useTime = 7;                        
			Item.useAnimation = 7;                                     
			Item.value = 250000;                       
			Item.rare = ItemRarityID.Cyan;                       
			Item.shoot = 10;                          
		    Item.shootSpeed = 50f;
          //item.useAnimation = 15;  //this would produce burst fire effect
		  //item.useTime = 5;
		  //item.reuseDelay = 15;           
		}

		   public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .66f;

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Stynger, 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.Cog, 8);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			
			//recipe.AddIngredient(ItemID.)
			recipe.AddTile(TileID.MythrilAnvil);		
			recipe.Register();
			
		}


    }
}}