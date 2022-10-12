
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Other;

namespace TrueSoul.Items.Mage
{
    public class SnowFist : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Ice Fist"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Casts weak fast homing fists and one strong high knockback fist.");
            Item.staff[Item.type] = true;
           
        }

        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.mana = 3;
            Item.DamageType = DamageClass.Magic;
            Item.width = 8;
            Item.height = 8;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = 5;
            Item.knockBack = 0;
            Item.value = 9000;
            Item.rare = 5;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<IcestaffProjectile>();
            Item.shootSpeed = 12f;
            Item.noMelee = false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(25));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<CorruptedFist>(), damage, knockback, player.whoAmI);
            }
            const int NumProjectiles2 = 1; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles2; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(7));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<CrimsonFist>(), damage * 3, knockback, player.whoAmI);
            }
            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CryoiteBar>(), 24);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
    public class CrimsonFist : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("NebulaBeam"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 1000;
            Projectile.light = 1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            
        }

        public override void AI()
        {
            if (Main.player[Projectile.owner].Center.X > Projectile.Center.X)
            {
                Projectile.spriteDirection = -1;
            }
            else
            {
                Projectile.spriteDirection = 1;
            }
        }
    }

    public class CorruptedFist : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("NebulaBeam"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 1000;
            Projectile.light = 1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (Main.player[Projectile.owner].Center.X > Projectile.Center.X)
            {
                Projectile.spriteDirection = -1;
            }
            else
            {
                Projectile.spriteDirection = 1;
            }
        }
    }
}