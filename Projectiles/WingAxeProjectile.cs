using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BonusVanillaStuff.Projectiles
{
	public class WingAxeProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Wing Axe");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);
			AIType = ProjectileID.PaladinsHammerFriendly;
		}

    }
}