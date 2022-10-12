using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TrueSoul.Items.Swift
{
    public class IceSwiftProjectile : ModProjectile
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
            Projectile.aiStyle = 3;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 1000;
            Projectile.light = 1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        int Timer = 0;

        public override void AI()
        {
            Projectile.rotation = 0;
            Timer++;
            Projectile.velocity.Y = 0;
            Projectile.velocity.X += 1;


            if (Timer == 25)
            {
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<IceSwiftProjectile>(), 40, 2, Main.myPlayer);
            }

            if (Timer >= 25)
            {
                Projectile.velocity.X = 0;
            }
        }
    }
}