using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TrueSoul.Items.Ranged
{
    public class SpectralProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimeball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 250;
            Projectile.timeLeft = 800;
            Projectile.light = 1f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
        int Timer = 0;
        public override void AI()
        {
            Projectile.velocity.Y = 0f;
            Timer++;
            if (Timer <= 20)
            {
                Projectile.velocity.X -= 0.8f;
            }
            if (Timer >= 20)
            {
                if (Timer <= 30)
                {
                    Projectile.velocity.Y = 0f;
                    Projectile.velocity.X = 0f;
                }
            }
            if (Timer >= 30)
            {
                Projectile.velocity.X += 1f;
            }
            if (Timer >= 90)
            {
                Timer -= 80;
            }
            base.AI();
        }

       
    }
}
