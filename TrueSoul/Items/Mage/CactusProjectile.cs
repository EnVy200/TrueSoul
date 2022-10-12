using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;


namespace TrueSoul.Items.Mage
{
    public class CactusProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 999999;
            Projectile.timeLeft = 10000;
            Projectile.light = 1f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 15, 1, 15, 0f, 0f, 0, default);
            Main.dust[dust].velocity *= 0.2f;
            Main.dust[dust].scale = Main.rand.Next(80, 115) * 0.013f;
            Main.dust[dust].noGravity = true;
        }
    }
}