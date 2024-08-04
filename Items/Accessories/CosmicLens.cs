using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BonusVanillaStuff.Items.Accessories {
    public class CosmicLens : ModItem {

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Gain defense equal to (ranged crit / 2)\nGain % ranged damage equal to (ranged crit / 2)%\nGain 40 armor penetration");
        }
        public override void SetDefaults()
        {
           
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(gold: 3);
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += (int)player.GetCritChance(DamageClass.Ranged) / 2;
            player.GetDamage(DamageClass.Ranged) *= 1 + player.GetCritChance(DamageClass.Ranged) / 200f;
            player.GetArmorPenetration(DamageClass.Generic) += 40;
            player.longInvince = true;
		}


    }
}