using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Items.Weapons{
public class Cataclysm : ModItem {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.InfernoFork);
            Item.damage = 200;       
            Item.useTime = 100;
            Item.useAnimation = 100;
			Item.autoReuse = true;
			Item.mana = 50;
            Item.knockBack = 5;
			Item.rare = ItemRarityID.Cyan;
            Item.value = 20000;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

            
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);


			float ceilingLimit = 500f;
			if (ceilingLimit > player.Center.Y - 200f) {
				ceilingLimit = player.Center.Y - 200f;
			}

			for (int i = 0; i < 25; i++) {
			
                position = player.Center - new Vector2(player.direction + Main.rand.NextFloat(-900, 900), 460f);
				position.Y -= Main.rand.NextFloat(100, 150); // * i;

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
                
                


				int proj1 = Projectile.NewProjectile(source, position, heading, type, damage * 2, knockback, player.whoAmI, 0f, ceilingLimit);
              
                Main.projectile[proj1].timeLeft = 150 + (int)Main.rand.NextFloat(150);
              
            }

			return false;
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 5);
		}

		public override void AddRecipes(){
			Recipe recipe = CreateRecipe();
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddIngredient(ItemID.MeteorStaff);
			recipe.AddIngredient(ItemID.InfernoFork);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddIngredient(ItemID.SoulofMight, 12);
			recipe.AddIngredient(ItemID.SoulofFright, 12);
			recipe.Register();
		}

    }
}