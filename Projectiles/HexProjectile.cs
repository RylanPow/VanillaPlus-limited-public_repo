using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BonusVanillaStuff.Projectiles
{
	public class HexProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Hex");
		}

		public override void SetDefaults() {
            Projectile.friendly = true; 
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.penetrate = 1;
		}



        public override void AI()
        {


            float angle = Main.rand.NextFloat(0f, MathHelper.TwoPi); 
    		float distance = Main.rand.NextFloat(2f, 15f); 

    		float x =  distance * (float)Math.Cos(angle);
    		float y =  distance * (float)Math.Sin(angle);
            
            Projectile.position.X += x;
            Projectile.position.Y += y;

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100, default, 1.2f);
			dust.noGravity = true;
			dust.velocity *= 0.4f;
            Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.2f);
			dust2.noGravity = true;
			dust2.velocity *= 0.4f;


	    }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 120);
            target.AddBuff(BuffID.CursedInferno, 120);
        }




    }
}