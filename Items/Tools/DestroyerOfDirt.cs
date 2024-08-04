using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Tools {
    
    public class DestroyerOfDirt : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Poor dirt had no idea what hit him");
		}

		
		public override void SetDefaults() {
			//Item.CloneDefaults(ItemID.MagnetSphere);
			Item.DamageType = DamageClass.Melee;
			Item.damage = 200;
			Item.useTime = 2;
			Item.useAnimation = 12;
			Item.mana = 0;
			Item.pick = 666;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.knockBack = 3;
			Item.value = 50000;
			Item.tileBoost += 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Red;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox) {
				for(int i = 0; i < 3; i++) {
				int dust1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 62);
				Main.dust[dust1].noGravity = false;
				}
			
		}

        public override void AddRecipes()
        {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StardustPickaxe);
			recipe.AddIngredient(ItemID.VortexPickaxe);
			recipe.AddIngredient(ItemID.NebulaPickaxe);
			recipe.AddIngredient(ItemID.SolarFlarePickaxe);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(ItemID.SpectreBar, 5);
			recipe.AddIngredient(ItemID.DirtBlock, 9999);

			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
        }



    }
    }

