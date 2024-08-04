
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BonusVanillaStuff.Projectiles
{
	public class LastWhisperProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Death");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.JestersArrow);
			AIType = ProjectileID.JestersArrow;

		}

        public override void AI()
        {	
		  	Projectile.penetrate = 1;	
			//LIGHTING
            Vector2 vector14 = Projectile.Center + Projectile.velocity * 2.5f;
            Lighting.AddLight(vector14, 1.2f, 1.2f, 1.2f);

            for (int i = 0; i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 100, default, 1f);
				dust.noGravity = true;
				dust.velocity *= 1f;
				
			}		
		}
        

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(target.boss == false) {
				target.life = 0;
            }
		}
  



	}
}




















