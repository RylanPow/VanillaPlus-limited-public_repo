using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using System;
using BonusVanillaStuff.Items.Accessories;
using BonusVanillaStuff.Items.Weapons;
using BonusVanillaStuff.Items.Tools;

/*


Random rnd = new Random();

Console.WriteLine("Generating 10 random numbers:");

for (int ctr = 1; ctr <= 10; ctr++)
    Console.WriteLine(rnd.Next(5)); //Random(a, b) outputs [a, b)

//OR, JUST USE math.random c# equivalent



*/

namespace BonusVanillaStuff.NPCs
{
    public class ModGlobalNPC : GlobalNPC
    {
   
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
               /*   FROM DOCS
               ItemDropRule.Common(ItemID.BeeGun) // Always drop 1 Bee Gun
               ItemDropRule.Common(ItemID.BeeGun, 8) // Drop 1 Bee Gun 1 out of every 8 times (12.5% chance)
               ItemDropRule.Common(ItemID.Torch, 4, 10, 15) // Drop a stack of 10 to 15 torches with 1 in 4 chance (25% chance)
               new CommonDrop(ItemID.Torch, 2, 10, 15, 5) // Drop a stack of 10 to 15 torches with 2 in 5 chance (40% chance)
               */

   			// First, we need to check the npc.type to see if the code is running for the vanilla NPC we want to change
   			if (npc.type == NPCID.MoonLordCore) {
   				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Aureola>(), 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CelestialCapacitor>(), 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CosmicLens>(), 3));
                //note: these are independent of each other.  if you only want ONE to drop,
                //roll a Main.rand.NextFloat(3); and have a switch

   			}

            if(npc.type == NPCID.CultistBoss) {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GreekFire>(), 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Truth>(), 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TouchOfDeath>(), 3));
                npcLoot.Add(ItemDropRule.Common(ItemID.CrimsonKey, 5));
                npcLoot.Add(ItemDropRule.Common(ItemID.CorruptionKey, 5));
                npcLoot.Add(ItemDropRule.Common(ItemID.JungleKey, 5));
                npcLoot.Add(ItemDropRule.Common(ItemID.DungeonDesertKey, 5));
                npcLoot.Add(ItemDropRule.Common(ItemID.HallowedKey, 5));
                npcLoot.Add(ItemDropRule.Common(ItemID.FrozenKey, 5));
            }

            if(npc.type == NPCID.EyeofCthulhu) {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeeingEye>(), 1));
            }

            if(npc.type == ModContent.NPCType<SpiritOfLight>()) {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofLight, 1, 2, 4));
            }
            if(npc.type == ModContent.NPCType<SpiritOfNight>()) {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofNight, 1, 2, 4));
            }

            if(npc.type == ModContent.NPCType<HarpyKnight>()) {
                npcLoot.Add(ItemDropRule.Common(ItemID.SoulofFlight, 1));
            }
            if(npc.type == ModContent.NPCType<ZombieKnight>()) {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RustedBlade>(), 1));
            }

   			// We can use other if statements here to adjust the drop rules of other vanilla NPC
   		    }

            public override void ModifyShop(NPCShop shop) { //NPC npc, string shopName, Item[] items) {
		    if(shop.NpcType == NPCID.ArmsDealer) 
            {
                //shop.item[nextSlot].SetDefaults(ModContent.ItemType<LoadedGun>());
                // nextSlot++;
                shop.Add<LoadedGun>();
	        }

















    }
        }
    }

      
//       public override void OnKill(NPC npc) { //NOW ONLY FOR FIRST TIME KILL EVENTS[like demon altars]!??!?!
//       
//              if(npc.type == ModContent.NPCType<SpiritOfLight>()) {
//                  Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, 3); 
//               }
//   
//               if(npc.type == ModContent.NPCType<SpiritOfNight>()) {
//                  Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, 3); 
//               }
//   
//   
//   
//               if(npc.type == NPCID.CultistBoss) {
//               switch (Main.rand.Next(3)) {
//   					case 0:
//   						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("LastWhisper").Type); //("CopperShortsword"));
//   						break;
//   					case 1:
//   						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("GreekFire").Type); //("CopperShortsword"));
//   						break;
//   					case 2:
//   						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("TouchOfDeath").Type); //("CopperShortsword"));
//   						break;
//   				}
//               }
//               if(npc.type == NPCID.MoonLordCore) { //th is will not override the moon lord's normal drop table
//                   switch (Main.rand.Next(3)) {
//                       case 0: 
//                           Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("Aureola").Type);
//                           break;
//                       case 1:
//                           Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("CelestialCapacitor").Type);
//                           break;
//                       case 2:
//                           Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("CosmicLens").Type);
//                           break;
//               
//   
//                   }
//               }
//   
//   
//   //if multiple enemies have a drop at the same probability, you can have multiple if statements here           
//   
//       //            if (npc.type == NPCID.Shark)
//       //            {
//       //                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampireKnives);
//       //            }
//       //            if (npc.type == NPCID.Crab)
//       //            {
//       //                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampireKnives);
//       //            }
//       //        }
//   //
//       }
//   }}
//   