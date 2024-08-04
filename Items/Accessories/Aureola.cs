using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Accessories {
    public class Aureola : ModItem {



        public override void SetDefaults()
		{
			Item.rare = ItemRarityID.Red;
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(gold: 3);
			Item.accessory = true;
			
		}

		

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 12;
			player.GetDamage(DamageClass.Magic) *= 1.2f; //does not autocomplete, probably works for melee and ranged too <-this was a glitch
			player.GetCritChance(DamageClass.Magic) += 20;
			player.longInvince = true;
			player.manaRegen *= 2;
			player.manaRegenDelay = 1;
			player.statManaMax2 += 50;
			//player.magicCrit += player.statManaMax2 / 10;
		}

		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("12 Defense \n20% increased magic damage and crit chance \n5x Mana Regen \nIncreases maximum mana by 50 \nIncreases length of invincibility after taking damage");
		}






    }
}