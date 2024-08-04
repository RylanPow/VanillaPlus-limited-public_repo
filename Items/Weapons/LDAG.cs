using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace BonusVanillaStuff.Items.Weapons {
    public class LDAG : ModItem {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("L.D.A.G.");
            // Tooltip.SetDefault("75% Chance to not consume ammo\nLaser Dolphin Annihilation Gun");
        }
       
        public override void SetDefaults() {
            Item.damage = 260; 
			Item.DamageType = DamageClass.Ranged; 
			Item.width = 40;
			Item.height = 20; 
			Item.useTime = 5; 
			Item.useAnimation = 5; 
            Item.crit = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 1;
			Item.value = Item.sellPrice(gold: 20); 
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item12; 
			Item.autoReuse = true; 
			Item.shoot = ProjectileID.LaserMachinegunLaser;                                                   
			Item.shootSpeed = 16f; 
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            int rand = Main.rand.Next(1, 4);
            if(rand == 0) {
                type = ProjectileID.LaserMachinegunLaser;
            }
            if(rand == 1) {
                type = ProjectileID.GreenLaser;
            }
            if(rand == 2) {
                type = ProjectileID.PurpleLaser;
            }
            if(rand == 3) {
                type = ProjectileID.MiniRetinaLaser;
            }
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(1)); 

				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);

            return true; 
		}       
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return false; 
		}

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SDMG);
            recipe.AddIngredient(ItemID.LastPrism);
            recipe.AddIngredient(ItemID.LaserRifle);
            recipe.AddIngredient(ItemID.LaserMachinegun);
            recipe.AddIngredient(ItemID.SpaceGun);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.Lens, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 12);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
        }
    }
}