using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BonusVanillaStuff.Items.Accessories {
    public class CelestialCapacitor : ModItem {

  

    public override void SetDefaults() {
			Item.rare = ItemRarityID.Red;
			Item.value = Item.sellPrice(gold: 3);
			Item.accessory = true;
	}

    public override void UpdateAccessory(Player player, bool hideVisual) {
        player.GetDamage(DamageClass.Melee) *= 1 + ((player.statLife / 20f)/100);
        player.GetAttackSpeed(DamageClass.Melee) *= 1 + ((player.statLife / 20f)/100);
        player.GetCritChance(DamageClass.Generic) += (player.statLife / 20);
        player.statDefense += (player.statLifeMax2 - player.statLife) / 10; 
        player.longInvince = true;
    }

    public override void SetStaticDefaults() {
      // Tooltip.SetDefault("Gain % Melee damage, speed, and crit equal to (current health / 20)%\nGain defense qual to (missing health / 10) \nIncreases length of invincibility after taking damage");
    }






    }
}