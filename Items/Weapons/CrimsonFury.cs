using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons
{
	public class CrimsonFury : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots 2 ichor arrows \nabsolutely furious!");
		}

		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Ranged; 
			Item.width = 40;
			Item.height = 20; 
			Item.useTime = 22; 
			Item.useAnimation = 22; 
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = 4; 
			Item.UseSound = SoundID.Item5; 
			Item.autoReuse = false; 
			Item.shoot = 10; 
			Item.shootSpeed = 55f; 
			Item.useAmmo = AmmoID.Arrow;
		}


		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
		if (type == ProjectileID.WoodenArrowFriendly) 
			{
				type = ProjectileID.IchorArrow; 
			}
 
			
			float numberProjectiles = 2;
			float rotation = MathHelper.ToRadians(3);
			position += Vector2.Normalize(velocity) * 30f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(); 
			recipe.AddIngredient(ItemID.MoltenFury, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.Ichor, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}