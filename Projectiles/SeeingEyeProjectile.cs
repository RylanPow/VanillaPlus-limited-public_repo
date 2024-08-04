using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BonusVanillaStuff.Projectiles
{
	public class SeeingEyeProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Eye");
		}

		public override void SetDefaults() {
            Projectile.damage = 0;
            //Projectile.light = 20f;
            Projectile.width = 40;
            Projectile.height = 40;
		}

        public override void AI()
        {		
			Vector2 mousePosition = Main.MouseWorld;


			float x = mousePosition.X - 16;
			float y = mousePosition.Y - 16;

			Vector2 pos = new Vector2(x, y); 

			Projectile.position = pos;
		    Vector2 vector14 = Projectile.Center;
            Lighting.AddLight(vector14, 1.5f, 1.5f, 1.5f);
	    }
	}
}