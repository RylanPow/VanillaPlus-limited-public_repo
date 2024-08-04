using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace BonusVanillaStuff.Projectiles
{
    public class FanOfKnivesProjectile : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Throwing knife");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			AIType = ProjectileID.ThrowingKnife;
			Projectile.velocity.X = 20;
			Projectile.velocity.Y = 20;
		}

	}
}
