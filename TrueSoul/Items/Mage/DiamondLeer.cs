
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TrueSoul.Items.Mage
{
    public class DiamondLeer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diamond Leer"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Shoots seven random gem projectiles with random damage.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 8 - 12;
            Item.mana = 5;
            Item.DamageType = DamageClass.Magic;
            Item.width = 8;
            Item.height = 8;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = 5;
            Item.knockBack = 2.5f;
            Item.value = 9000;
            Item.rare = 5;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CactusProjectile>();
            Item.shootSpeed = 12f;
            Item.noMelee = true;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int LuckProj = Main.rand.Next(1, 8);
            int Damage3 = Main.rand.Next(5, 12);
            const int NumProjectiles = 7; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                if (LuckProj == 1) type = ModContent.ProjectileType<DiamondLeProj>();
                if (LuckProj == 2) type = ModContent.ProjectileType<RubyLeProj>();
                if (LuckProj == 3) type = ModContent.ProjectileType<SapphireLeProj>();
                if (LuckProj == 4) type = ModContent.ProjectileType<TopazLeProj>();
                if (LuckProj == 5) type = ModContent.ProjectileType<AmythestLeProj>();
                if (LuckProj == 6) type = ModContent.ProjectileType<EmeraldLeProj>();
                if (LuckProj == 7) type = ModContent.ProjectileType<AmberLeProj>();






                Projectile.NewProjectileDirect(source, position, newVelocity, type, Damage3, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DiamondStaff);
            recipe.AddIngredient(ItemID.Diamond, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}