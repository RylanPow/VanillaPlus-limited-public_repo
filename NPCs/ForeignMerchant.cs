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
namespace BonusVanillaStuff.NPCs {
    [AutoloadHead] //magical, important line for town NPCs
    public class ForeignMerchant : ModNPC {
		public override string Texture  {
            //=> "BonusVanillaContent/NPCs/SuspiciousLookingNPC";  //was this originally
            get {return "BonusVanillaStuff/NPCs/ForeignMerchant";}
        }

		public const string ShopName = "Shop";

		//	public override string[] AltTextures { get {return new[] {"BonusVanillaStuff/NPCs/SuspiciousLookingNPC_Alt_1"};}}//{ "ExampleMod/NPCs/ExamplePerson_Alt_1" };
		//	public override bool IsLoadingEnabled(Mod mod) {
		//		name = "SuspiciousLookingNPC";
		//		return Mod.Properties/* tModPorter Note: Removed. Instead, assign the properties directly (ContentAutoloadingEnabled, GoreAutoloadingEnabled, MusicAutoloadingEnabled, and BackgroundAutoloadingEnabled) */.Autoload;
		//	}
		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			//DisplayName.SetDefault("Archibald");
			Main.npcFrameCount[NPC.type] = 26;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 4;
		}
		public override void SetDefaults() {
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
            return "Exotic wares from worlds unlike our own!";
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
   		public override List<string> SetNPCNameList()/* tModPorter Suggestion: Return a list of names */ {
			List<string> list = new List<string>();
			list.Add("Gustav Phillipe");
            list.Add("Don Lasagna");
            list.Add("Marcksus Strukov");
			return list;
		}


		public override void AddShops()
		{
			var npcShop = new NPCShop(Type, ShopName);

			if(GenVars.copperBar == 20)
            {
				npcShop.Add(ItemID.CopperOre);
            } else
            {
				npcShop.Add(ItemID.TinOre);
            }

			if (GenVars.ironBar == 11)
			{
				npcShop.Add(ItemID.LeadOre);
			}
			else
			{
				npcShop.Add(ItemID.IronOre);
			}

			if (GenVars.silverBar == 21)
			{
				npcShop.Add(ItemID.TungstenOre);
			}
			else
			{
				npcShop.Add(ItemID.SilverOre);
			}

			if (GenVars.goldBar == 19)
            {
				npcShop.Add(ItemID.PlatinumOre);
            } else
            {
				npcShop.Add(ItemID.GoldOre);
            }

			if(WorldGen.crimson)
            {
				npcShop.Add(ItemID.EbonstoneBlock);
				npcShop.Add(ItemID.CorruptSeeds);
				npcShop.Add(ItemID.DemoniteOre);
				npcShop.Add(ItemID.ShadowScale);
            } else
            {
				npcShop.Add(ItemID.CrimstoneBlock);
				npcShop.Add(ItemID.CrimsonSeeds);
				npcShop.Add(ItemID.CrimtaneOre);
				npcShop.Add(ItemID.TissueSample);
			}


			if(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
				npcShop.Add(ItemID.CobaltOre);
				npcShop.Add(ItemID.PalladiumOre);
				npcShop.Add(ItemID.MythrilOre);
				npcShop.Add(ItemID.OrichalcumOre);
				npcShop.Add(ItemID.AdamantiteOre);
				npcShop.Add(ItemID.TitaniumOre);
			}







			/*
						npcShop.Add(new Item(ItemID.TinOre)
						{ shopCustomPrice = Item.buyPrice()},
						new Condition("Queen Bee defeated", () => NPC.downedQueenBee)
						);

			*/


			/*
					   public override void ModifyActiveShop(string shopName, Item[] items) {
						if(GenVars.copperBar == 20){
						shop.item[nextSlot].SetDefaults(ItemID.TinOre);
						nextSlot++;
						} else {
						shop.item[nextSlot].SetDefaults(ItemID.CopperOre);
						nextSlot++;
						}
						if(GenVars.ironBar == 11) {
						shop.item[nextSlot].SetDefaults(ItemID.LeadOre);
						nextSlot++;
						} else {
						shop.item[nextSlot].SetDefaults(ItemID.IronOre);
						nextSlot++;
						}
						if(GenVars.silverBar == 21) {
						shop.item[nextSlot].SetDefaults(ItemID.TungstenOre);
						nextSlot++;
						} else {
						shop.item[nextSlot].SetDefaults(ItemID.SilverOre);
						nextSlot++;
						}
						if(GenVars.goldBar == 19) {
						shop.item[nextSlot].SetDefaults(ItemID.PlatinumOre);
						nextSlot++;
						} else {
						shop.item[nextSlot].SetDefaults(ItemID.GoldOre);
						nextSlot++;
						}
						if(WorldGen.crimson) {
						shop.item[nextSlot].SetDefaults(ItemID.DemoniteOre);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.CorruptSeeds);
						nextSlot++;
						} else {
						shop.item[nextSlot].SetDefaults(ItemID.CrimtaneOre);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.CrimsonSeeds);
						nextSlot++;
						}
						shop.item[nextSlot].SetDefaults(ItemID.Amethyst);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.Topaz);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.Sapphire);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.Emerald);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.Ruby);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.Diamond);
						nextSlot++;
						if(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3) {
						shop.item[nextSlot].SetDefaults(ItemID.CobaltOre);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.PalladiumOre);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.MythrilOre);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.OrichalcumOre);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.AdamantiteOre);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.TitaniumOre);
						nextSlot++;
						}*/
			npcShop.Register();
		}
    }
}