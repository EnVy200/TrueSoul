using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TrueSoul.Items.Swift
{
    public class StarSagiProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gel Ball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.


        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 99;
            Projectile.timeLeft = 100;
            Projectile.light = 1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }


    }
}