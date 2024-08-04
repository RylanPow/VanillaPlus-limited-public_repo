using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons {
    public class GrenadeCannon : ModItem {
        public override void SetDefaults() {
            Item.damage = 64; 
			Item.DamageType = DamageClass.Ranged; 
			Item.width = 40; 
			Item.height = 20;
			Item.useTime = 70;
			Item.useAnimation = 70; 
            Item.crit = 20;
			Item.useStyle = ItemUseStyleID.Shoot; 
			Item.noMelee = true;
			Item.knockBack = 4; 
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Red; 
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true; 
			Item.shoot = 10; 
			Item.shootSpeed = 16f; 
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            type = ProjectileID.Grenade;
            for (int i = 0; i < 7; i++)
			{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(10));
	

        
			
				Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(300)); 
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				int proj1 = Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
                Main.projectile[proj1].restrikeDelay = 1;
                
			}
            return false; 
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GrenadeLauncher, 1);
            recipe.AddIngredient(ItemID.Grenade, 999);
            recipe.AddIngredient(ItemID.Shotgun, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

}
}