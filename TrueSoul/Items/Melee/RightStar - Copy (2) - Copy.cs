using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul;

namespace TrueSoul.Items.Melee
{
    public class IcyClickProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.velocity.Y = 0f;
            Projectile.velocity.X = 0f;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 1;
            Projectile.light = 0.6f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.ArmorPenetration = 255;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.height = 40;
            Projectile.width = 40;
            Projectile.position = Main.MouseWorld;
            
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 35, false);
            target.AddBuff(BuffID.Slow, 200, false);
            target.AddBuff(BuffID.CursedInferno, 35, false);
            base.OnHitNPC(target, damage, knockback, crit);
        }
        public override void AI()
        {

            
            Projectile.velocity.Y = 0f;
            Projectile.velocity.X = 0f;
        }
    }
}