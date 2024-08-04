using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BonusVanillaStuff.Projectiles
{
	public class TouchOfDeathProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Death Scythe");
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.DeathSickle);
			AIType = ProjectileID.DeathSickle;
			
			Projectile.width = 2 * Projectile.width + 3;
			Projectile.height = 2 * Projectile.height + 2;
			Projectile.light = 1f;
		}



        public override void AI()
        {	
			Vector2 mousePosition = Main.MouseWorld;


			float x = mousePosition.X - 50;
			float y = mousePosition.Y - 50;

			Vector2 pos = new Vector2(x, y); 

			Projectile.position = pos;
			
			
        }




	}
}