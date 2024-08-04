using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Items.Weapons {
    public class Hex : ModItem {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Inflicts Burn and Cursed Flame");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WandofSparking);
            Item.damage = 20;
            Item.crit = 0;
            Item.mana = 20;
            Item.useTime = 60;
            Item.useTime = 60;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.shoot = ModContent.ProjectileType<HexProjectile>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            Vector2 mousePosition = Main.MouseWorld;


			float x = mousePosition.X;
			float y = mousePosition.Y;

			Vector2 pos = new Vector2(x, y); 
            Vector2 vel = new Vector2(0f, 0f);

			int proj1 = Projectile.NewProjectile(source, pos, vel, type, damage, knockback, player.whoAmI, 0f, 0f);
            Main.projectile[proj1].timeLeft = 20;


            return false;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ZombieArm);
            recipe.AddIngredient(ItemID.ViciousPowder, 15);
            recipe.AddIngredient(ItemID.VilePowder, 15);
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddIngredient(ItemID.CrimsonTorch);
            recipe.AddIngredient(ItemID.Deathweed, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }

}