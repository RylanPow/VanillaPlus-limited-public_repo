using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace BonusVanillaStuff.Projectiles
{
	public class PhantomKnivesProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Phantom Knife");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.VampireKnife);
			AIType = ProjectileID.VampireKnife;
			//projectile.penetrate = 3;
		

			Projectile.tileCollide = false;
			
			
		}
	}
}
