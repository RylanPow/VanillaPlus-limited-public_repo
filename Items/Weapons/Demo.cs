using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BonusVanillaStuff.Items.Weapons {
    public class Demo : ModItem {


        //used exclusively for proof of concept and testing

        public override void SetDefaults() {
            Item.damage = 400000000;
            Item.DamageType = DamageClass.Melee;
            Item.useAnimation = 15;
            Item.value = 5000;
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrystalShard, 5);
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }


    }
}