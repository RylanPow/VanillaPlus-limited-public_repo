using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader.Utilities;

namespace BonusVanillaStuff.NPCs 
{
        class ZombieKnight : ModNPC 
        {

            public override void SetStaticDefaults()
		    {
		    	Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie];
		    }
    
		    public override void SetDefaults()
		    {
				NPC.CloneDefaults(NPCID.Zombie);
				NPC.value = 50000;
				NPC.lifeMax = 950;
		    	NPC.damage = 25;
		    	NPC.defense = 25;           
                NPC.knockBackResist = 0.15f;   
		    	AIType = NPCID.Zombie;
		    	AnimationType = NPCID.Zombie;
		    }
    
		    public override float SpawnChance(NPCSpawnInfo spawnInfo)
		    {
				if(NPC.downedBoss1 && !NPC.AnyNPCs(NPC.type)) {
                    return SpawnCondition.OverworldNightMonster.Chance * 0.05f;
                } else {
                    return 0f;
                }
		
		    }

    








    
    }

}