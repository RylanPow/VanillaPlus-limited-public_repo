using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Items.Weapons 
{
	//this is actually listed as a tool on the wiki page
	public class OrbitalPlanetCracker : ModItem
	{
        public override void SetStaticDefaults() {
        /* Tooltip.SetDefault("\nWhen we say *planet cracker*, we REALLY mean *PLANET CRACKER*\n" + 
         $"\n[c/FF0000:WARNING: ALL ROCKETS WILL DESTROY TILES]"); */
        
    	}
		public override void SetDefaults() {
            Item.CloneDefaults(ItemID.RocketLauncher);
			Item.width = 26;
			Item.height = 42;

			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.autoReuse = true;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 80;
			Item.knockBack = 6;
			Item.crit = 6;
		
			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Red;


			Item.useAmmo = AmmoID.Rocket; 
			Item.shootSpeed = 50f; 

		}

    
	    public override Vector2? HoldoutOffset()
		{
			return new Vector2(20, 0);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        
            if(type == ProjectileID.RocketI || type ==  ProjectileID.RocketII || type ==  ProjectileID.RocketIII) {
                type = ProjectileID.RocketIV;
            }
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);

			float ceilingLimit = 500f;
			if (ceilingLimit > player.Center.Y - 200f) {
				ceilingLimit = player.Center.Y - 200f;
			}
	
			for (int i = 0; i < 3; i++) {
                position = player.Center - new Vector2(-1 * player.direction - Main.mouseX + 960, 460f);
				position.Y -= 200* i;

				Vector2 heading = target - position;

				if (heading.Y < 0f) {
					heading.Y *= -1f;
				}

				if (heading.Y < 20f) {
					heading.Y = 20f;
				}

				heading.Normalize();
				heading *= velocity.Length();
                heading.X = 0f;
				Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
                position.X = position.X + 30;
                Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
				position.X = position.X + 30;
                Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);

            }

			return false;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddIngredient(ItemID.RocketLauncher, 5);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddIngredient(ItemID.Actuator, 5);
			recipe.AddIngredient(ItemID.IronBar, 50);
			recipe.AddIngredient(ItemID.Wire, 20);
			recipe.Register();
		}

		
	}
}
