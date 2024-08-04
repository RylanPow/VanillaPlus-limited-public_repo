using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using BonusVanillaStuff.Projectiles;

namespace BonusVanillaStuff.Items.Weapons
{
	public class TerraInvicta : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults() {

			//Item.CloneDefaults(ItemID.MagnetSphere);
			//Item.DamageType = DamageClass.Melee;
			//Item.crit = 20;
			Item.crit = 0;
			Item.damage = 180;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.mana = 0;
			Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 50000;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("TerraInvictaProjectile").Type;

		}

	}
}
