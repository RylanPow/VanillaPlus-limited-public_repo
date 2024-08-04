using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons {
    public class BulletHose : ModItem {
        public override void SetStaticDefaults()
        {
    	}

        public override void SetDefaults() {
            Item.damage = 42; 
			Item.DamageType = DamageClass.Ranged; 
			Item.width = 40; 
			Item.height = 20; 
			Item.useTime = 6; 
			Item.useAnimation = 6; 
            Item.crit = 20;
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.noMelee = true; 
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 5); 
			Item.rare = ItemRarityID.Red; 
			Item.UseSound = SoundID.Item11; 
			Item.autoReuse = true; 
			Item.shoot = 10;
			Item.shootSpeed = 16f; 
			Item.useAmmo = AmmoID.Bullet;

        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            for (int i = 0; i < 3; i++)
			{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(7));
			//return true; //bullet spread

				Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(300)); // 30 degree spread.
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
            return true; 
		}

        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .66f;
		}


           public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Minishark, 1);
            recipe.AddIngredient(ItemID.Megashark, 1);
            recipe.AddIngredient(ItemID.SDMG, 1);
            recipe.AddIngredient(ItemID.Rope, 50);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
}
}