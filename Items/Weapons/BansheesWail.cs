using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BonusVanillaStuff.Projectiles;


namespace BonusVanillaStuff.Items.Weapons
{
    public class BansheesWail : ModItem
    {
        public override void SetStaticDefaults(){
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.SpectreStaff);
			Item.value = 200000;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.damage = 64;
			Item.shootSpeed = 4f;
            Item.mana = 18;
			Item.rare = ItemRarityID.Cyan; 
        }
	
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 8 + Main.rand.Next(6); 
            for (int i = 0; i < numberProjectiles; i++)
			{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(240)); 

        
			
				Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(0)); 
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
            return true; 
		}

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpectreStaff);
            recipe.AddIngredient(ItemID.SoulofFright, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 12);
            recipe.AddIngredient(ItemID.Ectoplasm, 7);


        }
       

    }
}
