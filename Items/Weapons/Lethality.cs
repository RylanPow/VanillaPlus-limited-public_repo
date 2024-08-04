using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Items.Weapons {
    public class Lethality : ModItem {
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shoot = ModContent.ProjectileType<LethalityProjectile1>();
            Item.damage = 52;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.knockBack = 5;
            Item.noMelee = true;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Yellow;
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ItemID.CrimtaneBar, 7);
            recipe.AddIngredient(ItemID.SpectreBar, 7);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.LifeFruit, 2);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}