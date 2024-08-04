using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BonusVanillaStuff.Projectiles
{
	public class ThrowingAxeProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("throwing axe");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Shuriken);
			AIType = ProjectileID.Shuriken;
		}

        public override void AI()
        {
          //projectile.rotation = (float)Math.Atan2((double)projectile.position.Y, (double)projectile.position.X) + 1.57f;
		  //Projectile.position.ToRotation();
			Projectile.penetrate = 1; //1

        }
		//public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		//{
		//	target.immune[Projectile.owner] = 2;//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~THIS LINE IS WHAT DETERMINES HOW OFTEN THE DAMAGE TICKS~~~~~~~~~~~~~~~~~~~~~~~
		//}





	}
}