using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BonusVanillaStuff.Items.Consumables

{
    public class MagusPotion : ModItem
    
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Grants effects of: Magic power, Mana regeneration, and Summoning potions");
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
            Item.buffType = BuffID.MagicPower;
            Item.buffTime = 36000; 
        }
        public override bool? UseItem(Player player) {
            player.AddBuff(BuffID.ManaRegeneration, 36000);
            player.AddBuff(BuffID.Summoning, 36000);
            return true;
        }
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MagicPowerPotion);
            recipe.AddIngredient(ItemID.ManaRegenerationPotion);
            recipe.AddIngredient(ItemID.SummoningPotion);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }

    }

}