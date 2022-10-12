using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using static Terraria.ModLoader.ModContent;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Melee;
using TrueSoul.Items.Ranged;
using TrueSoul.Items.TrueMelee;
using TrueSoul.Items.Placeables;
using TrueSoul.Items.Tools;
using TrueSoul.Items.Other;
using TrueSoul.Projectiles.Minions;
using TrueSoul.Items.Swift;

namespace ModGlobalNPCs
{
    public class ModGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // "denominator" is the chance of it appearing,
            // put down 1 for 100% (i.e. 1/1), 2 for 50% (i.e. 1/2), 3 for 33% (i.e. 1/3), 4 for 25% (i.e. 1/4), etc.
            if (npc.type == NPCID.Spazmatism)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Obamium>(), 1, 1, 6));
            if (npc.type == NPCID.Spazmatism)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ObamaCircle>(), 36, 1, 11));
            if (npc.type == NPCID.Retinazer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Obamium>(), 1, 1, 8));
            if (npc.type == NPCID.Retinazer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ObamaPrism>(), 36, 1, 1));
            if (npc.type == NPCID.TheDestroyer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Obamium>(), 1, 1, 9));
            if (npc.type == NPCID.TheDestroyer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ObamaSword>(), 36, 1, 1));
            if (npc.type == NPCID.SkeletronPrime)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Obamium>(), 1, 1, 12));
            if (npc.type == NPCID.SkeletronPrime)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ExampleSimpleMinionItem>(), 36, 1, 1));
            if (npc.type == NPCID.SkeletronPrime)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ObamaGun>(), 45, 1, 1));
            if (npc.type == NPCID.TheDestroyer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ObamaGun>(), 45, 1, 1));
            if (npc.type == NPCID.Spazmatism)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ObamaGun>(), 45, 1, 1));
            if (npc.type == NPCID.Retinazer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ObamaGun>(), 45, 1, 1));
            if (npc.type == NPCID.GoblinSummoner)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShadowflameBar>(), 2, 1, 7));
            if (npc.type == NPCID.BrainofCthulhu)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrainSagi>(), 4, 1, 1));
            if (npc.type == NPCID.EaterofWorldsBody)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EaterSagi>(), 67, 1, 1));
            if (npc.type == NPCID.IceGolem)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarlightOreSummonItem>(), 1, 1, 9));
            if (npc.type == NPCID.Retinazer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarlightOreSummonItem>(), 1, 1, 3));
            if (npc.type == NPCID.TheDestroyer)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarlightOreSummonItem>(), 1, 1, 3));
            if (npc.type == NPCID.SkeletronPrime)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarlightOreSummonItem>(), 1, 1, 3));

        }
    }
}