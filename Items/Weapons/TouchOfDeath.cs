using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BonusVanillaStuff.Projectiles;


namespace BonusVanillaStuff.Items.Weapons
{
	public class TouchOfDeath : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Touch of Death");
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.DeathSickle);
			Item.damage = 180;
            Item.crit = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
            Item.value = Item.sellPrice(gold: 12);
			Item.rare = ItemRarityID.Red;
			Item.shoot = ModContent.ProjectileType<TouchOfDeathProjectile>();
		}
	}
}
