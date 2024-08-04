using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace BonusVanillaStuff.Items.Weapons {
    public class RustedBlade : ModItem {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PlatinumBroadsword);
            Item.autoReuse = true;
            Item.damage = 26;
            Item.useAnimation = 19;
            Item.useTime = 19;
            Item.rare = 2;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) 
        {
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(BuffID.Poisoned, 1800);
		}
    }
}