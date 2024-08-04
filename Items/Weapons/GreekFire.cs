using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons {
    public class GreekFire : ModItem
    {

        public override void SetDefaults() {

            Item.CloneDefaults(ItemID.CursedFlames);
            Item.damage = 150;
            Item.crit = 20;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.mana = 10;

			Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 5);
        }


	    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 2 + Main.rand.Next(3); 
            for (int i = 0; i < numberProjectiles; i++)
			{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(7)); 	
				//Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12)); 
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
            return true; /
		}




    }
}