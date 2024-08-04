using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Items.Weapons
{
	public class FanOfKnives : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots 3 knives in a cone.  Pointy!");
		}
		
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.VampireKnives);
			Item.damage = 10;
			Item.shootSpeed = 50f;
			Item.rare = ItemRarityID.Green;
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ThrowingKnife, 300);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.AddIngredient(ItemID.Chain, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.ThrowingKnife, 300);
			recipe2.AddIngredient(ItemID.LeadBar, 20);
			recipe2.AddIngredient(ItemID.Chain, 10);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}


		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(10);                         
			type = ModContent.ProjectileType<FanOfKnivesProjectile>();
			position += Vector2.Normalize(velocity) * 20f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(5, 0);
		}

		
	}
}
