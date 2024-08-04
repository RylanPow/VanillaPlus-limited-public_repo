using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BonusVanillaStuff.Projectiles;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons {
    public class ThrowingAxe : ModItem {

        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Shuriken);
            Item.damage = 28;
            Item.useTime = 27;
            Item.knockBack = 3;
            Item.useAnimation = 27;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<ThrowingAxeProjectile>();
            
        }

     

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            Recipe recipe2 = CreateRecipe(2);
            recipe2.AddIngredient(ItemID.LeadBar, 1);
            recipe2.AddIngredient(ItemID.Wood, 5);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.Register();

        }













    }
}