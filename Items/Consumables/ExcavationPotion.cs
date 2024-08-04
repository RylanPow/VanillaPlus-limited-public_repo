using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BonusVanillaStuff.Items.Consumables
{
    public class ExcavationPotion : ModItem
    
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Grants effects of: Spelunker, Mining, Shine, Night Owl, Obsidian skin, and Dangersense potions");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 1);
            Item.buffType = BuffID.Spelunker; 
            Item.buffTime = 36000;
        }
        public override bool? UseItem(Player player) {
            player.AddBuff(BuffID.Mining, 36000);
            player.AddBuff(BuffID.Shine, 36000);
            player.AddBuff(BuffID.NightOwl, 36000);
            player.AddBuff(BuffID.Dangersense, 36000);
            player.AddBuff(BuffID.ObsidianSkin, 36000);
            return true;
        }
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpelunkerPotion);
            recipe.AddIngredient(ItemID.MiningPotion);
            recipe.AddIngredient(ItemID.ShinePotion);
            recipe.AddIngredient(ItemID.NightOwlPotion);
            recipe.AddIngredient(ItemID.ObsidianSkinPotion);
            recipe.AddIngredient(ItemID.TrapsightPotion);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }

    }

}