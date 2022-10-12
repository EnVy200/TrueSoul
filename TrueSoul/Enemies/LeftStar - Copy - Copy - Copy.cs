using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Potions;

namespace TrueSoul.Enemies
{
    public class FlamingEyeballTop : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Eyeball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
                        Projectile.velocity.Y = 0f;
            Projectile.velocity.X = 0f;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = false; 
            Projectile.hostile = true;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 2000;
            Projectile.light = 0.6f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.velocity.X = 1f;
            Projectile.damage -= 32;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<ForgivenessArdent>(), 300, false);
            base.OnHitPlayer(target, damage, crit);
        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.position.Y += 880;
            Projectile.position.X += Main.rand.Next(-560, 560);
            base.OnSpawn(source);
        }


        public override void AI()
        {
            Projectile.velocity.Y = -5f;







        }
    }
}