using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace BonusVanillaStuff.Items.Weapons {
    public class CrystalCoreStaff : ModItem {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Blast them with the power of jewelry!");
        }
        public override void SetDefaults()
        {
            Item.staff[Item.type] = true;
            Item.damage = 40;
            Item.DamageType = DamageClass.Magic;
            Item.crit = 4;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.autoReuse = true;  
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange; //orange
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.mana = 10;
            Item.knockBack = 3;
            Item.shootSpeed = 15f;
            Item.shoot = 10;
            Item.noMelee = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for(int i = 0; i < 3; i++) 
            {
            
            int gemProj = (int)Main.rand.NextFloat(0, 6);
            switch(gemProj) 
            {
                case 0:
                    type = ProjectileID.AmethystBolt;
                    break;
                case 1:
                    type = ProjectileID.TopazBolt;
                    break;
                case 2:
                    type = ProjectileID.SapphireBolt;
                    break;     
                case 3:
                    type = ProjectileID.EmeraldBolt;
                    break;
                case 4:
                    type = ProjectileID.RubyBolt;
                    break;
                case 5:
                    type = ProjectileID.DiamondBolt;
                    break; 
            }

            int proj1 = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
            Main.projectile[proj1].penetrate = 1;
            }
          
            return false;
        }

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.AmethystStaff);
            recipe.AddIngredient(ItemID.TopazStaff);
            recipe.AddIngredient(ItemID.SapphireStaff);
            recipe.AddIngredient(ItemID.EmeraldStaff);
            recipe.AddIngredient(ItemID.RubyStaff);
            recipe.AddIngredient(ItemID.DiamondStaff);
            recipe.AddIngredient(ItemID.MeteoriteBar, 20);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.Register();

        }

    }
}