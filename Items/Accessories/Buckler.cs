using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BonusVanillaStuff.Items.Accessories
{ 
	
	public class Buckler : ModItem
	{

	

		public override void SetDefaults()
		{
			Item.rare = ItemRarityID.Blue;
			Item.width = 11;
			Item.height = 10;
			Item.value = 200;
         

			Item.accessory = true;
			
		}
	    public override void UpdateAccessory(Player player, bool hideVisual)
		{
		
			player.statDefense += 6;
		
		}



		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("6 Defense");
		}



		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 30);
            recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();


            Recipe recipe2 = CreateRecipe();
		    recipe2.AddIngredient(ItemID.Wood, 30);
            recipe2.AddIngredient(ItemID.LeadBar, 6);
		    recipe2.AddTile(TileID.WorkBenches);
		    recipe2.Register();
		}
		}
	}


