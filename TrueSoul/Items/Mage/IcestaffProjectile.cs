using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Dusts;

namespace TrueSoul.Items.Mage
{
    public class IcestaffProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strong Laser"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 1000;
            Projectile.light = 2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.ArmorPenetration = 25;
            Projectile.alpha = 255;

        }

        public override void AI()
        {
            Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CyanSparkle>(), Projectile.velocity.X * 2f, Projectile.velocity.Y * 2f, Alpha: 128, Scale: 1.2f);
            DrawOffsetX = 0;
            DrawOriginOffsetY = 0;
            DrawOriginOffsetX = 0;
        }
        public override void Kill(int timeLeft)
        {
            if (Projectile.timeLeft <= 0)
            {
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<RandSpectralProjectileWeak>(), 6, 1, Main.myPlayer);
            }
        }

    }
}