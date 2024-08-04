using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BonusVanillaStuff.Projectiles
{

	public class BladesOfLightProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Blades of light");
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.JestersArrow);
			AIType = ProjectileID.JestersArrow;
			Projectile.tileCollide = false;
			Projectile.penetrate = 1; 
		}

   		public override void AI()
		{
			Projectile.tileCollide = false;
            Vector2 vector14 = Projectile.Center;
            Lighting.AddLight(vector14, 2f, 2f, 2f);

			Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 100, default, 1.5f);
			dust.noGravity = true;
			dust.velocity *= 0.75f;
		}

}
}