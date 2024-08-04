   using Terraria;
   using Terraria.ID;
   using Terraria.ModLoader;
   using BonusVanillaStuff.Projectiles;
   
   namespace BonusVanillaStuff.Items.Weapons
   {
       public class FusionCutter : ModItem
   	{
   		public override void SetStaticDefaults()
   		{
   		}
   
   		public override void SetDefaults()
   		{
   			Item.damage = 380;
   			Item.noMelee = true;
   			Item.DamageType = DamageClass.MeleeNoSpeed;
   			Item.channel = true; //Channel so that you can hold the weapon [Important]
   			Item.rare = ItemRarityID.Red;
   			Item.width = 28;
   			Item.height = 30;
   			Item.useTime = 20;
   			Item.crit = 45;
   			Item.UseSound = SoundID.Item15;
   			Item.useStyle = ItemUseStyleID.Shoot;
   			Item.shootSpeed = 14f;
   			Item.useAnimation = 20;
   			Item.shoot = ModContent.ProjectileType<FusionCutterProjectile1>();
			Item.knockBack = 3;
   			Item.value = Item.sellPrice(gold: 20);
   		}
   
   
   
   		public override void AddRecipes()
   		{
   			Recipe recipe = CreateRecipe();
   			recipe.AddIngredient(ItemID.FragmentSolar, 25);
   			recipe.AddIngredient(ItemID.FragmentStardust, 25);
   			recipe.AddIngredient(ItemID.LunarBar, 40);
   			recipe.AddIngredient(ItemID.MechanicalGlove, 1);
   			recipe.AddIngredient(ItemID.Wire, 20);
   			recipe.AddIngredient(ItemID.Switch, 1);
   			recipe.AddTile(TileID.LunarCraftingStation);
   			recipe.Register();
   		}
   	}
   }
   