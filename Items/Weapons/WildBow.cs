using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons
{
	public class WildBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wild Bow");
			// Tooltip.SetDefault("Turns wooden arrows into powerful venom arrows");
		}
		public override void SetDefaults()
		{	
			Item.damage = 23; 
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40; 
			Item.height = 20; 
			Item.useTime = 34; 
			Item.useAnimation = 34; 
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = 10000; 
			Item.rare = ItemRarityID.Green; 
			Item.UseSound = SoundID.Item5; 
			Item.autoReuse = false; 
			Item.shoot = 10;
			Item.shootSpeed = 12f; 
			Item.useAmmo = AmmoID.Arrow; 
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(type == ProjectileID.WoodenArrowFriendly) {
				type = ProjectileID.VenomArrow;
			}
            int proj1 = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
          
            return false;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(); 
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddIngredient(ItemID.Stinger, 3);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.RichMahogany, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}