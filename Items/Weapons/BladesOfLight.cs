using Terraria; //needed for everything
using Terraria.DataStructures; //needed for most projectile related work
using Terraria.ID; //needed to use terraria sounds, copying item behaviors, rarity IDs, etc.
using Terraria.ModLoader; //also needed for everything in general
using Microsoft.Xna.Framework; //Terraria uses Microsoft XNA isntead of, for example, Unity
using System; //various
using BonusVanillaStuff.Projectiles; //the path to your projectiles or whatever folder


namespace BonusVanillaStuff.Items.Weapons //the path to whatever folder the item is saved in
{
	public class BladesOfLight : ModItem //this item extends the Terraria ModItem class
	{
		public override void SetStaticDefaults() {  //used to be used for tooltips and display name among other things
													//tooltips are now done in the localization folder as of tModLoader 1.4
		}
		public override void SetDefaults() { //where the item's properties are set
			Item.damage = 400;
			Item.DamageType = DamageClass.Magic; //melee, magic, ranged, summoner, or a unique type you create
			Item.width = 26;  //the weight and height of the item hitbox when dropped on ground.  drops through ground if not set
			Item.height = 42;
			Item.useStyle = ItemUseStyleID.Shoot; //item's "use style"; e.g., swing for broadswords, shoot for guns and bows, holdup for magic mirror, etc
			Item.useAnimation = 40; //animation of the item use speed.  often same speed as usetime
			Item.useTime = 40; //actual usetime.  can produce certainy effects when not the same as useAnimation
			Item.autoReuse = true; //so left click can be held for auto reuse, e.g. autoswing
			Item.mana = 20; //mana cost per use
			Item.knockBack = 6; //knockback value
			Item.crit = 50; //crit chance
			Item.value = Item.buyPrice(gold: 5); //item price.  see: buy vs sell price in Terraria
			Item.rare = ItemRarityID.Red; //the color rarity of the item, IDs jsut correspond to integers 
			Item.UseSound = SoundID.Item28; //the sound played on use.  main use for Terraria.ID import

			Item.shoot = ModContent.ProjectileType<BladesOfLightProjectile>(); 
			//what projectile the weapon fires.  usually modifed in Shoot().  see projectiles for corresponding projectile file
		}
	
		//If shoot has been set in SetDefaults(), the specifics of what is fired is handled here
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {		
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			for (int i = 0; i < 10; i++) {
				         
                float angle = Main.rand.NextFloat(0f, MathHelper.TwoPi); 

    		    float x = distance * (float)Math.Cos(angle) - 30;
    		    float y = distance * (float)Math.Sin(angle);
                
                Vector2 SpawnOffset = new Vector2(x, y);
                
                position = player.Center + SpawnOffset; 
                Vector2 heading = target - position;

				int proj1 = Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, 0f);
				Main.projectile[proj1].tileCollide = false;
			    Main.projectile[proj1].localNPCHitCooldown = 1;
			}
			//if Item.shoot is set to anything in SetDefaults(), return false here will prevent that projectile from being shot.  For example, if Item.shoot = 10, meaning Item.shoot was set to purification powder, return false prevents purification powder from rendering, instead replacing it with what is in this method
			return false;
		}

        public override void AddRecipes()
        {
			//recipes are created in this method. create a new recipe, add ingredients, add a tile(crafting station), then register recipe. can create a second recipe, e.g. Recipe recipe2 = CreateRecipe(); to have multiple recipes for one item
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.EmpressBlade);
			recipe.AddIngredient(ItemID.BeamSword);
			recipe.AddIngredient(ItemID.SkyFracture);
			recipe.AddIngredient(ItemID.SoulofLight, 100);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.SoulofFlight, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

        }
        
		public override Vector2? HoldoutOffset()
		{
			//this changes the location of where the item's sprite when used
			return new Vector2(-3, -15);
		}
    	}	
	}


