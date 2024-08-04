using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BonusVanillaStuff.Projectiles;


namespace BonusVanillaStuff.Items.Weapons
{
    public class PrismaticDivergence : ModItem
    {
        public override void SetStaticDefaults(){
            //Tooltip.SetDefault("Shoots 3-homing crystal bolts");
        }

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.CrystalSerpent);
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.damage = 27;
			Item.shootSpeed = 55f;
			Item.rare = ItemRarityID.Cyan; 
			Item.mana = 8;

        }

			public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 2 + Main.rand.Next(3); // + 0, 1, or 2
            for (int i = 0; i < numberProjectiles; i++)
			{
			//old way: Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7)); 
			//old way: speedX = perturbedSpeed.X;
			//old way: speedY = perturbedSpeed.Y;
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(7));

			float scale = 1f - (Main.rand.NextFloat() * .4f);

	

			//perturbedSpeed = perturbedSpeed * scale; 
			//Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			float rotation = MathHelper.ToRadians(3);
			Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
			Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			
			
			}
            return false; //only put one return true here obviously, returning after the bullet spread will halt the process before it gets to this
			//return false; // return false because we don't want tmodloader to shoot projectile


			//REPLACE "new Vector2(speedX, speedY)" with "velocity"!
			//REPLACE "Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);"
		}	//with "Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);"
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalStorm);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.PixieDust, 25);
			recipe.AddIngredient(ItemID.LightShard, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
       

    }
}
