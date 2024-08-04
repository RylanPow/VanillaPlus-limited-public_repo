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

	public class TideCasterProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Tide orb");
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.DemonScythe);
			AIType = ProjectileID.DemonScythe;
            //Projectile.velocity *= 0.25f;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 1; 

		}

   		public override void AI()
		{

			Projectile.tileCollide = false;
            Projectile.light = 0f;
			
			//lighting
            Vector2 vector14 = Projectile.Center;// + Projectile.velocity * 2.5f;
            Lighting.AddLight(vector14, 0f, 0f, 2.5f);
		for (int i = 0; i < 2; i++) {
			Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Water, 0f, 0f, 100, default, 2f);
			dust.noGravity = true;
			dust.velocity *= 0.75f;
		}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
				Vector2 projPos = new Vector2(target.position.X, target.position.Y);
				int rand1 = (int)Main.rand.NextFloat(0, 120);
				int rand2 = (int)Main.rand.NextFloat(120, 240);
				int rand3 = (int)Main.rand.NextFloat(240, 360);

				Vector2 velVec1 = new Vector2(5f, 5f).RotatedBy(MathHelper.ToDegrees(rand1));
				Vector2 velVec2 = new Vector2(5f, 5f).RotatedBy(MathHelper.ToDegrees(rand2));
				Vector2 velVec3 = new Vector2(5f, 5f).RotatedBy(MathHelper.ToDegrees(rand3));

				int proj1 = Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), projPos, velVec1, ProjectileID.WaterStream, damageDone / 3, 0f, base.Projectile.owner, 0f, 0f);
				int proj2 = Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), projPos, velVec2, ProjectileID.WaterStream, damageDone / 3, 0f, base.Projectile.owner, 0f, 0f);
				int proj3 = Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), projPos, velVec3, ProjectileID.WaterStream, damageDone / 3, 0f, base.Projectile.owner, 0f, 0f);

				Main.projectile[proj1].timeLeft = 30;
				Main.projectile[proj1].penetrate = 2;

				Main.projectile[proj2].timeLeft = 30;
				Main.projectile[proj2].penetrate = 2;
				
				Main.projectile[proj3].timeLeft = 30;
				Main.projectile[proj3].penetrate = 2;



        }
}
}