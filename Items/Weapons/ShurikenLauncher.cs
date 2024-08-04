using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using BonusVanillaStuff.Items;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Items.Weapons{
    public class ShurikenLauncher : ModItem {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.DamageType = DamageClass.Ranged;
            Item.crit = 4;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.autoReuse = true;  
            Item.value = 5000;
            Item.rare = 2; 
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.knockBack = 3;
            Item.shootSpeed = 20f;
            Item.shoot = ProjectileID.Shuriken;
            Item.noMelee = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ProjectileID.Shuriken;
            
            int proj1 = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
            Main.projectile[proj1].friendly = true;
            
            return false;
        }
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddIngredient(ItemID.Chain, 10);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.Shuriken, 999);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
          