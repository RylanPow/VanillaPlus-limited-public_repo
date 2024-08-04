using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Items.Tools {
    public class SeeingEye : ModItem {
        public override void SetStaticDefaults() {
            //DisplayName.SetDefault("Loaded Gun");
            // Tooltip.SetDefault("As opposed to a non-seeing eye\nHold left click to produce light at cursor");
        }
        public override void SetDefaults(){
            Item.damage = 0;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.holdStyle = 1;
            
            Item.rare = 4;
            //Item.noUseGraphic = true;
            Item.crit = 0;
            Item.value = 10000;
            Item.autoReuse = true;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.shoot = ModContent.ProjectileType<SeeingEyeProjectile>();

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			
            Vector2 target = new Vector2(Main.mouseX, Main.mouseY); 
            Vector2 velVec = new Vector2(0f, 0f);


            int proj1 = Projectile.NewProjectile(source, target, velVec, type, 0, 0, player.whoAmI, 0f);
              
            Main.projectile[proj1].timeLeft = 2;
              
                
            
			return false;
		}
}}
