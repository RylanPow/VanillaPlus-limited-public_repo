using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace BonusVanillaStuff.Items.Weapons {
    public class OvergrowthTendrils : ModItem {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");
    	}

        public override void SetDefaults() {
            Item.damage = 142; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.DamageType = DamageClass.Ranged; // sets the damage type to ranged
			Item.width = 40; // hitbox width of the item
			Item.height = 20; // hitbox height of the item
			Item.useTime = 13; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 13; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.crit = 20;
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the item (swinging, holding out, etc)
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = Item.sellPrice(gold: 3); // how much the item sells for (measured in copper)
			Item.rare = ItemRarityID.Yellow; // the color that the item's name will be in-game
			Item.UseSound = SoundID.NPCHit20; // The sound that this item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = ProjectileID.ChlorophyteBullet; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 35f; // the speed of the projectile (measured in pixels per frame)
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            int shots = (int)Main.rand.NextFloat(3, 7);
            for (int i = 0; i < shots; i++)
			{
            int spread = (int)Main.rand.NextFloat(30, 50);
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(spread));
			//return true; //bullet spread

        
			
				Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(200 + 3*spread)); // 30 degree spread.
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				int proj = Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
                Main.projectile[proj].timeLeft = spread - 5;
			}
            return false; //only put one return true here obviously, returning after the bullet spread will halt the process before it gets to this
			//return false; // return false because we don't want tmodloader to shoot projectile
		}


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PiranhaGun);
			recipe.AddIngredient(ItemID.SoulofNight, 40);
			recipe.AddIngredient(ItemID.MudBlock, 99);
			recipe.AddIngredient(ItemID.BloodWater, 20);
			recipe.AddIngredient(ItemID.JungleGrassSeeds, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.Vine, 5);
            recipe.AddIngredient(ItemID.LifeFruit, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
        }

}
}