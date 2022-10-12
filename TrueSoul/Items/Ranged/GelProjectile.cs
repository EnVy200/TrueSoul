using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TrueSoul.Items.Ranged
{
    public class Explosion : ModProjectile
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
            Projectile.penetrate = 999;
            Projectile.timeLeft = 300;
            Projectile.light = 1f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.position.Y -= 8;
            Projectile.position.X -= 8;
        }

        public override void AI()
        {
            Projectile.alpha += 1;
            Projectile.velocity.Y = 0;
            Projectile.velocity.X = 0;
        }

       
    }
}
