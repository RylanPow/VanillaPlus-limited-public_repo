using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BonusVanillaStuff.Projectiles;


namespace BonusVanillaStuff.Items.Weapons
{
    public class PlagueBringer : ModItem
    {
        public override void SetStaticDefaults(){
        }
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ScourgeoftheCorruptor);
			Item.damage = 120;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.rare = ItemRarityID.Red; 
			Item.shootSpeed = 50f;
			Item.useStyle = ItemUseStyleID.Shoot;

        }


		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ScourgeoftheCorruptor);
			recipe.AddIngredient(ItemID.CursedFlame, 30);
			recipe.AddIngredient(ItemID.SoulofNight, 200);
			recipe.AddIngredient(ItemID.Ectoplasm, 7);
            recipe.AddIngredient(ItemID.SoulofFright, 7);
            recipe.AddIngredient(ItemID.SoulofMight, 7);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 5;
			float rotation = MathHelper.ToRadians(7);
			position += Vector2.Normalize(velocity) * 20f;

			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
    }
}
