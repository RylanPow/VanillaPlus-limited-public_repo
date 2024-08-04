using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BonusVanillaStuff.Items.Consumables

{
    public class CombatPotion : ModItem

    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Grants effects of: Wrath, Rage, Lifeforce, Endurance, Ironskin, and Regeneration potions");
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
            Item.buffType = BuffID.Wrath; 
            Item.buffTime = 36000; 
        }
        public override bool? UseItem(Player player) {
            player.AddBuff(BuffID.Rage, 36000);
            player.AddBuff(BuffID.Lifeforce, 36000);
            player.AddBuff(BuffID.Endurance, 36000);
            player.AddBuff(BuffID.Ironskin, 36000);
            player.AddBuff(BuffID.Regeneration, 36000);
            return true;
        }
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WrathPotion);
            recipe.AddIngredient(ItemID.RagePotion);
            recipe.AddIngredient(ItemID.LifeforcePotion);
            recipe.AddIngredient(ItemID.EndurancePotion);
            recipe.AddIngredient(ItemID.IronskinPotion);
            recipe.AddIngredient(ItemID.RegenerationPotion);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }

    }

}