using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace BonusVanillaStuff.Projectiles
{
	public class TerraInvictaProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Terra spirit");
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.MagnetSphereBall);
			AIType = ProjectileID.MagnetSphereBall;
			Projectile.width = 2 * Projectile.width + 3;
			Projectile.height = 2 * Projectile.height + 2;
			Projectile.light = 1f;
		}

        public override void AI()
        {
			/*
			Vector2 mousePosition = Main.MouseWorld;


			float x = mousePosition.X - 100 + Main.rand.Next(200);
			float y = mousePosition.Y - 100 + Main.rand.Next(200);

			Vector2 pos = new Vector2(x, y); 

			Projectile.position = pos;
			*/
			Vector2 mousePosition = Main.MouseWorld;





    		float angle = Main.rand.NextFloat(0f, MathHelper.TwoPi); // Random angle in radians
    		float distance = Main.rand.NextFloat(20f, 200f); // Random distance within 100 units radius

    		float x = mousePosition.X + distance * (float)Math.Cos(angle) - 30;
    		float y = mousePosition.Y + distance * (float)Math.Sin(angle);
			

    		Vector2 spawnPosition = new Vector2(x, y);
			Projectile.tileCollide = false;
    		Projectile.position = spawnPosition;

			//rotation
			//Projectile.rotation = (float)Math.Atan2((double)Projectile.position.Y, (double)Projectile.position.X) + 1.57f;
		  	Projectile.velocity.ToRotation();
			
			DrawOriginOffsetX = 0;
			DrawOffsetX = -((32 / 2) - Projectile.width / 2);
			DrawOriginOffsetY = ((32 / 2) - Projectile.height / 2);


        

            //lighting
            Vector2 vector14 = Projectile.Center;// + Projectile.velocity * 2.5f;
            Lighting.AddLight(vector14, 0, 0.8f, 0);

            int newWidth = Projectile.width + 10;
            Projectile.light = 0f;

        }

	}
}