using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using BonusVanillaStuff.Projectiles;
using System.Diagnostics;

namespace BonusVanillaStuff.Projectiles
{
	public class LethalityProjectile2 : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lethality");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.GreenLaser);
            AIType = ProjectileID.GreenLaser;
		}
        public override void AI() {
            Projectile.light = 0f;
            Vector2 vector14 = Projectile.Center + Projectile.velocity * 2.5f;
            Lighting.AddLight(vector14, 1.2f, 0, 0);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
           target.immune[Projectile.owner] = 4;
        }

    }
}