using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace BonusVanillaStuff.Items.Weapons{
    public class FishLauncher : ModItem {
        public override void SetDefaults()
        {
            Item.damage = 95;
            Item.DamageType = DamageClass.Ranged;
            Item.crit = 4;
            Item.useTime =      70;
            Item.useAnimation = 70;
            Item.autoReuse = true;  
            Item.value = 5000;
            Item.rare = ItemRarityID.Orange; 
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAmmo = AmmoID.Bullet;
            Item.knockBack = 3;
            Item.shootSpeed = 15f;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ProjectileID.MiniSharkron;
            int shots = (int)Main.rand.NextFloat(0, 3);
            
            if(shots > 0) {
                int proj1 = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
                Main.projectile[proj1].friendly = true;
            }
            if(shots == 0) {
                Vector2 velocity1 = velocity;
                velocity1 = velocity1.RotatedBy(MathHelper.ToRadians(1));
                Vector2 velocity2 = velocity;
                velocity2 = velocity2.RotatedBy(-1*MathHelper.ToRadians(1));

          
                int proj1 = Projectile.NewProjectile(source, position, velocity1, type, damage, knockback, player.whoAmI, 0f, 0f);
                int proj2 = Projectile.NewProjectile(source, position, velocity2, type, damage, knockback, player.whoAmI, 0f, 0f);
                
                Main.projectile[proj1].friendly = true;
                Main.projectile[proj2].friendly = true;
            }
          
            return false;
        }
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-11, 0);
		}
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.SharkFin, 5);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
