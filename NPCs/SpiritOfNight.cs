using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader.Utilities;

namespace BonusVanillaStuff.NPCs 
{
        class SpiritOfNight : ModNPC 
        {

            public override void SetStaticDefaults()
		    {
		    	// DisplayName.SetDefault("Spirit of Night");
		    	Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.DungeonSpirit];
		    }
    
		    public override void SetDefaults()
		    {
				NPC.CloneDefaults(NPCID.DungeonSpirit);
		    	NPC.width = 18;
		    	NPC.height = 40;
		    	NPC.damage = 40;
		    	NPC.defense = 3;              
		    	NPC.lifeMax = 450;
		    	NPC.HitSound = SoundID.NPCHit1;
		    	NPC.DeathSound = SoundID.NPCDeath6;
		    	NPC.value = 400f;
		    	NPC.knockBackResist = 1.5f;
		    	NPC.aiStyle = 56; 
		    	AIType = NPCID.DungeonSpirit;
		    	AnimationType = NPCID.DungeonSpirit;
    
		    }
    
		    public override float SpawnChance(NPCSpawnInfo spawnInfo)
		    {
		    	//return SpawnCondition.OverworldNightMonster.Chance * 5.1f;
				//return Main.hardMode && spawnInfo.spawnTileY <= Main.worldSurface ? 0.1f : 0f; //if < surface, no spawn chance
				if(Main.hardMode && (!WorldGen.crimson)) {
					return SpawnCondition.Corruption.Chance * 1f;
				} else 
				if(Main.hardMode && WorldGen.crimson) {
					return SpawnCondition.Crimson.Chance * 1f;
				}
				else return 0f;
		    }
			public override void AI()
        	{
           		Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.CorruptTorch, 0f, 0f, 100, default, 1f); 
        	}
    
		    public override void HitEffect(NPC.HitInfo hit)
		    {
				
		    }
    }

}