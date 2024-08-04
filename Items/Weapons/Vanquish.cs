using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;


namespace BonusVanillaStuff.Items.Weapons {
    public class Vanquish : ModItem {
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.SniperRifle);
            Item.damage = 3600;
            Item.shootSpeed = 50f;
            Item.crit = 50;
            Item.useTime = 70;
            Item.rare = ItemRarityID.Red;
            Item.useAnimation = 70;
        }
       public override void HoldItem(Player player)
       {
           player.scope = true;
       }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.MoonlordBullet;
			}
      
           
			    Vector2 perturbedSpeed = velocity;
		
				float scale = 200f;
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		
            return false; 
		}       

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SniperRifle);
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
        }
    }
}