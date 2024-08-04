using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using BonusVanillaStuff.Projectiles;
using BonusVanillaStuff.Items.Weapons;


namespace BonusVanillaStuff.Items.Weapons
{
	public class PhantomKnives : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots 5 knives in a cone that go through walls. Spooky!");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.VampireKnives);
			Item.DamageType = DamageClass.Melee;
			Item.damage = 36;
			Item.shootSpeed = 20f;
			Item.crit = 10;
			Item.rare = ItemRarityID.Lime;
			Item.material = false;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 5);
		
		}


		float knivesOffset = 45f;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 5; //+ Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(12);
			type = ModContent.ProjectileType<PhantomKnivesProjectile>();
			position += Vector2.Normalize(velocity) * knivesOffset;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}


		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{	
				Item.CloneDefaults(ItemID.VampireKnives);
				Item.DamageType = DamageClass.Melee;
				Item.damage = 36;
				Item.shootSpeed = 20f;
				Item.crit = 10;
				Item.autoReuse = true;
				Item.rare = ItemRarityID.Lime;
				knivesOffset = 270f;           
			}
			
			else
			{
				
				Item.CloneDefaults(ItemID.VampireKnives);
				Item.DamageType = DamageClass.Melee;
				Item.damage = 36;
				Item.shootSpeed = 20f;
				Item.crit = 10;
				Item.autoReuse = true;
				Item.rare = ItemRarityID.Lime;
				knivesOffset = 25f;            

			}
			return base.CanUseItem(player);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(5, 0);
		}




		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 20);
			recipe.AddIngredient(Mod, "FanOfKnives");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

	}
}
