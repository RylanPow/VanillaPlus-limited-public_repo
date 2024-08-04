using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace BonusVanillaStuff.Items.Weapons {
    public class TacticalCrossbow : ModItem
    {

       
       public override void SetDefaults()
       {
           Item.CloneDefaults(ItemID.WoodenBow);
           Item.damage = 230;
           Item.useTime = 45;
           Item.useAnimation = 45;
           Item.crit = 50;
           Item.rare = ItemRarityID.Yellow;
           Item.value = 10000;
           Item.shootSpeed *= 5f;  
           Item.knockBack = 8;
        
           
       }
       public override void HoldItem(Player player)
       {
           player.scope = true;
       }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            if (type == ProjectileID.WoodenArrowFriendly) 
			{
				type = ProjectileID.BoneArrow; 
			}
      
           
			    Vector2 perturbedSpeed = velocity;
		
				float scale = 5f;
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
		
            return false;
		}       
 

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedRepeater);
            recipe.AddIngredient(ItemID.RifleScope);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
        }

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}
       




    }
}





