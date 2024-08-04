using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BonusVanillaStuff.Projectiles;


namespace BonusVanillaStuff.Items.Weapons 
{
	public class BladesOfLight : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 42;


			Item.useStyle = ItemUseStyleID.Shoot;

			Item.useAnimation = 40;  
			Item.useTime = 40; 

			Item.autoReuse = true;
			Item.mana = 20;
			Item.DamageType = DamageClass.Magic;
			Item.damage = 400;
			Item.knockBack = 6;
			Item.crit = 50;
			
			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item28;

			Item.shoot = ModContent.ProjectileType<BladesOfLightProjectile>(); 
		}
	
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {		
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			for (int i = 0; i < 10; i++) {
				         
                float angle = Main.rand.NextFloat(0f, MathHelper.TwoPi); 

    		    float x = distance * (float)Math.Cos(angle) - 30;
    		    float y = distance * (float)Math.Sin(angle);
                
                Vector2 SpawnOffset = new Vector2(x, y);
                
                position = player.Center + SpawnOffset; 
                Vector2 heading = target - position;

				int proj1 = Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, 0f);
				Main.projectile[proj1].tileCollide = false;
			    Main.projectile[proj1].localNPCHitCooldown = 1;
			}

			return false;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.EmpressBlade);
			recipe.AddIngredient(ItemID.BeamSword);
			recipe.AddIngredient(ItemID.SkyFracture);
			recipe.AddIngredient(ItemID.SoulofLight, 100);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFlight, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

        }
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, -15);
		}

    }	
	}


