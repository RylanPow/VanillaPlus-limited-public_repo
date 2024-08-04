using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BonusVanillaStuff.Items.Accessories
{ 
	[AutoloadEquip(EquipType.Wings)]
	public class QuestionablyEthicalHoverboard : ModItem
	{

	

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Hoverboard);
			Item.rare = ItemRarityID.Red;
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(platinum: 2);

			Item.accessory = true;
			
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 800;
			player.statDefense += 10;
			player.GetDamage(DamageClass.Generic) *= 1.1f;
		}



		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("10 Defense \n 10% increased damage \n -1 Soul \n You DON'T want to know. Trust me, you don't...");
		}



		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 55f;
			acceleration *= 3.5f;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Hoverboard, 1);
			recipe.AddIngredient(ItemID.LunarBar, 20);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.CopperShortsword, 1);
			recipe.AddIngredient(ItemID.DeathSickle, 1);
			recipe.AddIngredient(ItemID.GuideVoodooDoll, 1);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 10);

			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}

