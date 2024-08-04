using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace BonusVanillaStuff.Items.Weapons {
    
    public class Truth : ModItem {
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("7 round burst \nOnly the first shot consumes ammo\nIf you didn't believe me before, maybe this will convince you...");
		}

       	public override void SetDefaults() {
			Item.damage = 72;
            Item.crit = 30;                         
			Item.DamageType = DamageClass.Ranged;                       
			Item.width = 40;                          
			Item.height = 20;                         
			Item.useTime = 20;                        
			Item.useAnimation = 20;                   
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;                      
			Item.knockBack = 4;                       
			Item.value = Item.sellPrice(gold: 8);                     
			Item.rare = ItemRarityID.Red;            
			Item.UseSound = SoundID.Item11; //11 for gun           
		 	Item.autoReuse = true;                    
			Item.shoot = 10;                          
			Item.shootSpeed = 12f;                    
			Item.useAmmo = AmmoID.Bullet;  

            Item.useAnimation = 14;
			Item.useTime = 2;
			Item.reuseDelay = 20;           
		}


        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return !(player.itemAnimation < Item.useAnimation - 1);
		}

	


    }
}