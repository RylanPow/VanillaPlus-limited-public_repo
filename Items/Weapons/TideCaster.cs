 using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BonusVanillaStuff.Projectiles;


namespace BonusVanillaStuff.Items.Weapons 
{
	public class TideCaster : ModItem
	{
		public override void SetDefaults() {
            Item.CloneDefaults(ItemID.DemonScythe);
			Item.width = 26;
			Item.height = 42;

			Item.useStyle = ItemUseStyleID.Shoot;
			Item.staff[Item.type] = true;

			Item.useAnimation = 40;  
			Item.useTime = 40; 

			Item.autoReuse = true;
			//Item.mana = 12;
			Item.DamageType = DamageClass.Magic;
			Item.damage = 40;
			Item.knockBack = 6;
			Item.crit = 4;
			
			Item.value = Item.buyPrice(silver: 60);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item28;

			Item.shoot = ModContent.ProjectileType<TideCasterProjectile>(); 
			Item.shootSpeed = 0.02f;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			for (int i = 0; i < 1; i++) {
                float angle = Main.rand.NextFloat(0f, MathHelper.TwoPi);
    		    float distance = 70f;
    		    float x = distance * (float)Math.Cos(angle) - 30;
    		    float y = distance * (float)Math.Sin(angle);
                Vector2 SpawnOffset = new Vector2(x, y);
                position = player.Center + SpawnOffset; 
                Vector2 heading = target - position;
				heading *= 0.02f;
				int proj1 = Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, 0f);
				Main.projectile[proj1].tileCollide = false;
			    Main.projectile[proj1].localNPCHitCooldown = 1;

			}

			return false;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AquaScepter);
			recipe.AddIngredient(ItemID.Sapphire, 8);
			recipe.AddIngredient(ItemID.Coral, 3);
			recipe.AddIngredient(ItemID.Seashell, 1);
			recipe.AddIngredient(ItemID.PalmWood, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

        }
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, -15);
		}

    }
	}


