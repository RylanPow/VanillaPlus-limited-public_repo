using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;
using BonusVanillaStuff.Items.Weapons;

namespace BonusVanillaStuff.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class StayTuned: ModNPC
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Stay tuned!");

			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { // Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}

		public override void SetDefaults() {
			NPC.width = 18;
			NPC.height = 40;
			NPC.damage = 14;
			NPC.defense = 0;
			NPC.lifeMax = 1000000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = 60f;
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3;

			AIType = NPCID.Zombie;
			AnimationType = NPCID.Zombie; 
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LastWhisper>()));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TerraInvicta>())); 
			
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if(NPC.downedMoonlord && !NPC.AnyNPCs(NPC.type)) {
				return SpawnCondition.OverworldNightMonster.Chance * 0.05f; 
			} else {
				return 0f;
			}

		public override void HitEffect(NPC.HitInfo hit) {
		}

	}
}
