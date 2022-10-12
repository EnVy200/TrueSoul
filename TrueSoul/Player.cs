
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using TrueSoul.Enemies;

namespace TrueSoul
{
    public class Playe : ModPlayer
    {
        public int ClickAOE = 1;
        public int ClickAOEAdd = 0;
        public int Clicks = 0;
        public bool slimeShoes = false;
        
        

        
        public override void PostUpdate()
        {

            if (Player.velocity.X != 0 && slimeShoes)
            {
                if (Player.velocity.Y == 0f)
                {
                    int dust = Dust.NewDust(Player.position + new Vector2(0, Player.height - 4), Player.width, 4, 16, 0f, 0f, 0, Colors.RarityBlue, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0;
                }
            }
            if (NPC.AnyNPCs(ModContent.NPCType<ArdentPhase1>()))
                {
                Player.statDefense += 170;
                Player.lifeRegen = 4;
   

            }


        }
        
        public override void ResetEffects()
        {
            slimeShoes = false;
        }
    }
}