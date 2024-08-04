using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader.Utilities;

namespace BonusVanillaStuff.NPCs 
{
        class SpiritOfLight : ModNPC 
        {

            public override void SetStaticDefaults()
		    {
		    	// DisplayName.SetDefault("Spirit of Light");
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
		    	if(Main.hardMode) {
					return SpawnCondition.OverworldHallow.Chance * 1f;
				} else return 0f;
		    }

        public override void AI()
        {
           Dust dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, DustID.PinkTorch, 0f, 0f, 100, Microsoft.Xna.Framework.Color.Pink, 1f); 
        }

		    public override void HitEffect(NPC.HitInfo hit)
		    {
            
		    }
    }

}