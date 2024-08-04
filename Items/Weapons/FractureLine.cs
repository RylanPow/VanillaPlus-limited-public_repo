using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace BonusVanillaStuff.Items.Weapons{
     public class FractureLine : ModItem {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TitaniumSword);
            Item.damage = 70;
            Item.knockBack = 2;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useTurn = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) 
        {
            //IEntitySource source = player.GetSource_ItemUse(base.Item, null);
			int proj1 = Projectile.NewProjectile(player.GetSource_FromThis(null), target.Center, new Vector2(0f, 0f), ProjectileID.CrystalBullet, damageDone/3, hit.Knockback, player.whoAmI, 0f, 0f);
            target.HitSound = SoundID.Item27;
            Main.projectile[proj1].timeLeft = 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(ItemID.CrystalShard, 30);
            recipe.AddIngredient(ItemID.SoulofSight, 25);
            recipe.AddIngredient(ItemID.SoulofLight, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
    
}