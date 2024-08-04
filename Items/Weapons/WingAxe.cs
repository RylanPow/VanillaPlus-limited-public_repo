using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BonusVanillaStuff.Projectiles;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons {
    public class WingAxe : ModItem {

        public override void SetStaticDefaults()
        {
            
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PaladinsHammer);
            Item.damage = 78;
            Item.useTime = 27;
            Item.knockBack = 3;
            Item.useAnimation = 27;
            Item.rare = ItemRarityID.LightPurple;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<WingAxeProjectile>();
            Item.shootSpeed *= 2.4f;
            
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 8);
            recipe.AddIngredient(ItemID.SoulofFlight, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.PixieDust, 12);
            recipe.AddIngredient(ItemID.Feather, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.TitaniumBar, 8);
            recipe2.AddIngredient(ItemID.SoulofFlight, 1);
            recipe2.AddIngredient(ItemID.SoulofLight, 5);
            recipe2.AddIngredient(ItemID.PixieDust, 12);
            recipe2.AddIngredient(ItemID.Feather, 6);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();

        }

    }
}