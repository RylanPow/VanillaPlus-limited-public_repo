using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader.Utilities;

namespace BonusVanillaStuff.NPCs 
{
        class HarpyKnight : ModNPC 
        {

            public override void SetStaticDefaults()
            {
                // DisplayName.SetDefault("Harpy Knight");
                Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Harpy];
            }

            public override void SetDefaults()
            {
                NPC.CloneDefaults(NPCID.Harpy);
                NPC.lifeMax = 300;
                NPC.damage = 50;
                NPC.defense = 25;
				NPC.knockBackResist = 0.4f;
                AIType = NPCID.Harpy;
                AnimationType = NPCID.Harpy;
            }

            public override float SpawnChance(NPCSpawnInfo spawnInfo)
            {
				return Main.hardMode ? SpawnCondition.Sky.Chance : 0f;
            }


            public override void HitEffect(NPC.HitInfo hit)
            {

            }

    }

}