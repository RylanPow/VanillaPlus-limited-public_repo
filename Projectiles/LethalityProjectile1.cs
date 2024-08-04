using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Projectiles
{
	public class LethalityProjectile1 : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lethality");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.GreenLaser);
			AIType = ProjectileID.GreenLaser;
			Projectile.friendly = true; //MUST include this to do damage.  false by default
            //Projectile.damage = 5; //setting this here does nothing; overrided in Projectile.NewProjectile()
			Projectile.timeLeft = 50; 
		}

        public override void AI()
        {
			//Projectile.penetrate = 2; //1
			//Projectile.restrikeDelay = 1;
			//Projectile.maxPenetrate = 1;
			Projectile.penetrate = 1;
			Projectile.light = 0f;

			
			Vector2 vector14 = Projectile.Center + Projectile.velocity * 1.5f;
            Lighting.AddLight(vector14, 1.2f, 0, 0);
			
            for (int i = 0; i < 1; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CrimtaneWeapons, 0f, 0f, 100, default, 1f);
				dust.noGravity = true;
				dust.velocity *= 2f;
				
			}

			//Projectile.rotation = Projectile.velocity.ToRotation();
		
        }

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
	
			Vector2 pos1 = target.Center;
			pos1.X += 11;
			pos1.Y -= 4;
			int proj1 = Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), pos1, 
			Vector2.Zero, ModContent.ProjectileType<LethalityProjectile2>(),
			base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);

			Main.projectile[proj1].timeLeft = 90;
			Main.projectile[proj1].penetrate = -1;
	

			Vector2 vel2 = new Vector2(0.001f, 0.001f).RotatedBy(MathHelper.ToDegrees(85));
			Vector2 pos2 = target.Center;
			pos2.X -= 13;
			pos2.Y += 23;
			int proj2 = Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), pos2, 
			vel2, ModContent.ProjectileType<LethalityProjectile2>(),
			base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);

			Main.projectile[proj2].timeLeft = 90;
			Main.projectile[proj2].penetrate = -1;

	
		}



	}
}