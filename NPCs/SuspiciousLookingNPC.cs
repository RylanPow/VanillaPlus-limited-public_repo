using System;
using BonusVanillaStuff.Items;
using BonusVanillaStuff.Items.Weapons;
using BonusVanillaStuff.Projectiles;
using BonusVanillaStuff.Items.Consumables;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
namespace BonusVanillaStuff.NPCs {    [AutoloadHead] //magical, important line for town NPCs
		public class SuspiciousLookingNPC : ModNPC {		public override string Texture  {
            //=> "BonusVanillaContent/NPCs/SuspiciousLookingNPC";  //was this originally
            get {return "BonusVanillaStuff/NPCs/SuspiciousLookingNPC";}
        }
		//	public override string[] AltTextures { get {return new[] {"BonusVanillaStuff/NPCs/SuspiciousLookingNPC_Alt_1"};}}//{ "ExampleMod/NPCs/ExamplePerson_Alt_1" };	//	public override bool IsLoadingEnabled(Mod mod) {
		//		name = "SuspiciousLookingNPC";
		//		return Mod.Properties/* tModPorter Note: Removed. Instead, assign the properties directly (ContentAutoloadingEnabled, GoreAutoloadingEnabled, MusicAutoloadingEnabled, and BackgroundAutoloadingEnabled) */.Autoload;
		//	}
		public const string ShopName = "Shop";
		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			//DisplayName.SetDefault("Archibald");
			Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 4;
		}		public override void SetDefaults() {
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.Guide;
		}        
		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
		//	button2 = "Awesomeify";
		//	if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
		//		button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
		}
		public override string GetChat() {
			int rand = (int)Main.rand.NextFloat(0, 3);
			switch(rand){
				case 0:
					return "Pssst, hey kid! Ya like boss summoning items?";
				case 1:
					return "A fine day to be well-hatted.";
				case 2:
					return "What? this? I normally walk like this.";
			}
			return "presumably unreachable code";
        }
		public override void OnChatButtonClicked(bool firstButton, ref string shop)
		{
			shop = ShopName;
		}
			
	
				
		public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */ {
			if (NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3) {                                  
                   return true;
                }
				return false;
            }
     

		public override List<string> SetNPCNameList()
		{
			return new List<string> {
				"Archibald",
				"Pierre Bourne",
				"Guy N. Cognito",
			};
		}

		public override void AddShops()
		{
			var npcShop = new NPCShop(Type, ShopName)
			//.Add<SuspiciousLookingBulb>()

			.Add(new Item(ItemID.SuspiciousLookingEye)
			{ shopCustomPrice = Item.buyPrice(silver: 350) })
			.Add(new Item(ItemID.SlimeCrown)
			{ shopCustomPrice = Item.buyPrice(silver: 400) })
			.Add(new Item(ItemID.BloodySpine)
			{ shopCustomPrice = Item.buyPrice(silver: 400) })
			.Add(new Item(ItemID.WormFood)
			{ shopCustomPrice = Item.buyPrice(silver: 400) })
			.Add(new Item(ItemID.ClothierVoodooDoll)
			{ shopCustomPrice = Item.buyPrice(silver: 600) });


			npcShop.Add(new Item(ItemID.Abeemination)
			{ shopCustomPrice = Item.buyPrice(silver: 600) }, 
			new Condition("Queen Bee defeated", () => NPC.downedQueenBee)
			);

			npcShop.Add(new Item(ItemID.GuideVoodooDoll)
			{ shopCustomPrice = Item.buyPrice(gold: 10) },
			new Condition("Wall of Flesh defeated", () => Main.hardMode)
			);

			npcShop.Add(new Item(ItemID.QueenSlimeCrystal)
			{ shopCustomPrice = Item.buyPrice(gold: 12) },
			new Condition("Queen Slime defeated", () => NPC.downedQueenSlime)
			);

			npcShop.Add(new Item(ItemID.MechanicalWorm)
			{ shopCustomPrice = Item.buyPrice(gold: 15) },
			new Condition("Destroy defeated", () => NPC.downedMechBoss1)
			);

			npcShop.Add(new Item(ItemID.MechanicalEye)
			{ shopCustomPrice = Item.buyPrice(gold: 15) },
			new Condition("The Twins defeated", () => NPC.downedMechBoss2)
			);

			npcShop.Add(new Item(ItemID.MechanicalSkull)
			{ shopCustomPrice = Item.buyPrice(gold: 15) },
			new Condition("Skeleton Prime defeated", () => NPC.downedMechBoss3)
			);

			npcShop.Add(new Item(ModContent.ItemType<SuspiciousLookingBulb>())
			{ shopCustomPrice = Item.buyPrice(gold: 18) },
			new Condition("Plantera defeated", () => NPC.downedPlantBoss)
			);

			npcShop.Add(new Item(ItemID.LihzahrdPowerCell)
			{ shopCustomPrice = Item.buyPrice(gold: 20) },
			new Condition("Golem defeated", () => NPC.downedGolemBoss)
			);

			npcShop.Add(new Item(ItemID.TruffleWorm)
			{ shopCustomPrice = Item.buyPrice(gold: 25) },
			new Condition("Duke Fishron defeated", () => NPC.downedFishron)
			);

			npcShop.Add(new Item(ItemID.EmpressButterfly)
			{ shopCustomPrice = Item.buyPrice(gold: 35) },
			new Condition("Skeleton Prime defeated", () => NPC.downedEmpressOfLight)
			);

			npcShop.Add(new Item(ItemID.CelestialSigil)
			{ shopCustomPrice = Item.buyPrice(gold: 45) },
			new Condition("Skeleton Prime defeated", () => NPC.downedMoonlord)
			);



			//public NPCShop Add(Item item, params Condition[] condition)
			//params means it accepts a variable number of Condition[] objects


			//			.Add(new Item(ItemID.ClothierVoodooDoll)
			//			{ shopCustomPrice = Item.buyPrice(silver: 700) })
			//			.Add(new Item(ItemID.GuideVoodooDoll)
			//			{ shopCustomPrice = Item.buyPrice(gold: 10) })
			//			.Add(new Item(ItemID.QueenSlimeCrystal)
			//			{ shopCustomPrice = Item.buyPrice(gold: 12) })
			//			.Add(new Item(ItemID.MechanicalWorm)
			//			{ shopCustomPrice = Item.buyPrice(gold: 15) })
			//			.Add(new Item(ItemID.MechanicalEye)
			//			{ shopCustomPrice = Item.buyPrice(gold: 15) })
			//			.Add(new Item(ItemID.MechanicalSkull)
			//			{ shopCustomPrice = Item.buyPrice(gold: 12) })
			//			.Add(new Item(ModContent.ItemType<Items.Consumables.SuspiciousLookingBulb>())
			//			{ shopCustomPrice = Item.buyPrice(gold: 18) })
			//			.Add(new Item(ItemID.LihzahrdPowerCell)
			//			{ shopCustomPrice = Item.buyPrice(gold: 20) })
			//			.Add(new Item(ItemID.TruffleWorm)
			//			{ shopCustomPrice = Item.buyPrice(gold: 25) })
			//			.Add(new Item(ItemID.CelestialSigil)
			//			{ shopCustomPrice = Item.buyPrice(gold: 40) })
			//			; 





			//.Add<EquipMaterial>()
			//.Add<BossItem>()
			//.Add(new Item(ModContent.ItemType<Items.Placeable.Furniture.ExampleWorkbench>()) { shopCustomPrice = Item.buyPrice(copper: 15) }) // This example sets a custom price, ExampleNPCShop.cs has more info on custom prices and currency. 


			//.Add<ExampleGun>(Condition.MoonPhasesQuarter1)
			//.Add<Items.Ammo.ExampleBullet>(Condition.MoonPhasesQuarter1)
			//.Add<ExampleStaff>(Condition.MoonPhasesQuarter2)


			//if (ModContent.GetInstance<ExampleModConfig>().ExampleWingsToggle)
			//{
			//	npcShop.Add<ExampleWings>(ExampleConditions.InExampleBiome);
			//}

			//if (ModContent.TryFind("SummonersAssociation/BloodTalisman", out ModItem bloodTalisman))
			//{
			//	npcShop.Add(bloodTalisman.Type);
			//}
			npcShop.Register(); // Name of this shop tab
		}

		/*
				public override void ModifyShop(NPCShop shop)
				{ //string shopName, Item[] items) {
					  //            shop.item[nextSlot].SetDefaults(ItemID.SuspiciousLookingEye); // One method of adding a Vanilla Item
					  //            shop.item[nextSlot].shopCustomPrice = 25000;//in terms of coppers, like everything else
					  //            nextSlot++;

					shop.Add(new Item(ItemID.SuspiciousLookingEye)
					{
						shopCustomPrice = 25000,
					});
					//
					//			shop.Add(ItemID.SuspiciousLookingEye);
					//            shop.item[nextSlot].SetDefaults(ItemID.BloodySpine); 
					//            shop.item[nextSlot].shopCustomPrice = 35000;
					//            nextSlot++;
					//            shop.item[nextSlot].SetDefaults(ItemID.WormFood); 
					//            shop.item[nextSlot].shopCustomPrice = 35000;
					//            nextSlot++;
					//			if(NPC.downedSlimeKing) {
					//            shop.item[nextSlot].SetDefaults(ItemID.SlimeCrown);
					//            shop.item[nextSlot].shopCustomPrice = 40000; 
					//            nextSlot++;}
					//			if(NPC.downedQueenBee) {
					//            shop.item[nextSlot].SetDefaults(ItemID.Abeemination); 
					//             shop.item[nextSlot].shopCustomPrice = 60000; 
					//            nextSlot++;
					//			}
					//            shop.item[nextSlot].SetDefaults(ItemID.ClothierVoodooDoll); 
					//             shop.item[nextSlot].shopCustomPrice = 70000; 
					//            nextSlot++;
					//			if(Main.hardMode) {
					//            shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll); 
					//             shop.item[nextSlot].shopCustomPrice = 80000; 
					//            nextSlot++;
					//			}
					//            //shop.item[nextSlot].SetDefaults(ItemID.QueenSlimeCrystal); queen slime doesn't exist yet
					//			if(NPC.downedMechBossAny) {
					//            shop.item[nextSlot].SetDefaults(ItemID.MechanicalWorm); 
					//            shop.item[nextSlot].shopCustomPrice = 100000; 
					//            nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.MechanicalEye);
					//			shop.item[nextSlot].shopCustomPrice = 100000; 
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.MechanicalSkull);
					//			shop.item[nextSlot].shopCustomPrice = 100000; 
					//			nextSlot++;
					//			}
					//			if(NPC.downedQueenSlime) {
					//			shop.item[nextSlot].SetDefaults(ItemID.QueenSlimeCrystal); //don't forget parentheses after <>
					//			shop.item[nextSlot].shopCustomPrice = 100000;
					//			nextSlot++;
					//			}			if(NPC.downedPlantBoss) {
					//			shop.item[nextSlot].SetDefaults(ModContent.ItemType<SuspiciousLookingBulb>()); //don't forget parentheses after <>
					//			shop.item[nextSlot].shopCustomPrice = 125000;
					//			nextSlot++;
					//			}
					//			if(NPC.downedGolemBoss) {
					//            shop.item[nextSlot].SetDefaults(ItemID.LihzahrdPowerCell);
					//            shop.item[nextSlot].shopCustomPrice = 150000;  
					//            nextSlot++;
					//			}
					//			if(NPC.downedFishron) {
					//            shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm); 
					//            shop.item[nextSlot].shopCustomPrice = 200000; 
					//            nextSlot++;
					//			}
					//			if(NPC.downedMoonlord) {
					//            shop.item[nextSlot].SetDefaults(ItemID.CelestialSigil); 
					//            shop.item[nextSlot].shopCustomPrice = 400000; 
					//            nextSlot++;
					//			}			if(GenVars.copperBar == 20){
					//			shop.item[nextSlot].SetDefaults(ItemID.TinOre);
					//			nextSlot++;
					//			} else {
					//			shop.item[nextSlot].SetDefaults(ItemID.CopperOre);
					//			nextSlot++;
					//			}			if(GenVars.ironBar == 11) {
					//			shop.item[nextSlot].SetDefaults(ItemID.LeadOre);
					//			nextSlot++;
					//			} else {
					//			shop.item[nextSlot].SetDefaults(ItemID.IronOre);
					//			nextSlot++;
					//			}			if(GenVars.silverBar == 21) {
					//			shop.item[nextSlot].SetDefaults(ItemID.TungstenOre);
					//			nextSlot++;
					//			} else {
					//			shop.item[nextSlot].SetDefaults(ItemID.SilverOre);
					//			nextSlot++;
					//			}			if(GenVars.goldBar == 19) {
					//			shop.item[nextSlot].SetDefaults(ItemID.PlatinumOre);
					//			nextSlot++;
					//			} else {
					//			shop.item[nextSlot].SetDefaults(ItemID.GoldOre);
					//			nextSlot++;
					//			}
					//			if(WorldGen.crimson) {
					//			shop.item[nextSlot].SetDefaults(ItemID.DemoniteOre);
					//			nextSlot++;
					//			} else {
					//			shop.item[nextSlot].SetDefaults(ItemID.CrimtaneOre);
					//			nextSlot++;
					//			}			shop.item[nextSlot].SetDefaults(ItemID.Amethyst);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.Topaz);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.Sapphire);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.Emerald);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.Ruby);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.Diamond);
					//			nextSlot++;
					//			if(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3) {
					//			shop.item[nextSlot].SetDefaults(ItemID.CobaltOre);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.PalladiumOre);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.MythrilOre);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.OrichalcumOre);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.AdamantiteOre);
					//			nextSlot++;
					//			shop.item[nextSlot].SetDefaults(ItemID.TitaniumOre);
					//			nextSlot++;
					//			}	
				}
				   /* shop.item[nextSlot].SetDefaults(mod.GetItem("Item")); // One method of adding a Modded Item         
					nextSlot++
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Item>()); // One method of adding a Modded Item
					nextSlot++
					if (Main.moonPhase < 4) { // Checks for the moon phase            
						shop.item[nextSlot].SetDefaults(ItemID.BowlofSoup));
						nextSlot++
					}

					*/

	}
    }
