using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace BonusVanillaStuff.Items.Weapons {
    
    public class ClockworkBow : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Three round burst \n Only the first shot consumes ammo");
		}

       	public override void SetDefaults() {
			Item.damage = 32;                         
			Item.DamageType = DamageClass.Ranged;                       
			Item.width = 40;                          
			Item.height = 20;                         
			Item.useTime = 20;                        
			Item.useAnimation = 20;                   
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;                      
			Item.knockBack = 4;                       
			Item.value = Item.sellPrice(gold: 1);                      
			Item.rare = ItemRarityID.Pink;            
			Item.UseSound = SoundID.Item5;           
		 	Item.autoReuse = true;                    
			Item.shoot = 10;                          
			Item.shootSpeed = 16f;                    
			Item.useAmmo = AmmoID.Arrow;  

            Item.useAnimation = 15;
			Item.useTime = 5;
			Item.reuseDelay = 15;           
		}


        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return !(player.itemAnimation < Item.useAnimation - 2);
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedRepeater, 1);
			recipe.AddIngredient(ItemID.Cog, 15);
			recipe.AddIngredient(ItemID.TitaniumBar, 15);
			recipe.AddTile(TileID.MythrilAnvil);		
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.HallowedRepeater, 1);
			recipe2.AddIngredient(ItemID.Cog, 15);
			recipe2.AddIngredient(ItemID.AdamantiteBar, 15);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.Register();
			
		}


    }
}