using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using BonusVanillaStuff.Projectiles;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons {
    public class LastWhisper : ModItem {


    public override void SetDefaults() {
        //item.CloneDefaults(ItemID.WoodenBow);
        Item.rare = ItemRarityID.Red;
        Item.value = Item.sellPrice(platinum: 2);
        Item.AllowReforgeForStackableItem = false;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.UseSound = SoundID.Item5;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.width = 50;
        Item.height = 50;
        Item.notAmmo = true;
        Item.damage = 1;
        Item.shootSpeed = 80f;
        Item.shoot = ModContent.ProjectileType<LastWhisperProjectile>();
        

    }
    public override Vector2? HoldoutOffset()
	{
		return new Vector2(-2, 0);
	}

    }
}