using BonusVanillaStuff.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BonusVanillaStuff.Items.Weapons
{
	public class CorruptionPike : ModItem 
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("A particularly pointy pike.  Putrid, too!");
		}

		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 26; //increasing this will make the spear fly WAAAAAAAY out of your hands. 
			Item.useTime = 26;
			Item.shootSpeed = 2.7f;
			Item.knockBack = 1.5f;
			Item.width = 32;
			Item.height = 32;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 10);

			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; 
			Item.noUseGraphic = true; 
			Item.autoReuse = true; 

			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<CorruptionPikeProjectile>();
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
	}
}