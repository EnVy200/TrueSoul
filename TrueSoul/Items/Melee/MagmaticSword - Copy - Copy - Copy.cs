using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using ExampleMod.Content.DamageClasses;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Other;
using TrueSoul.DamageClasses;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Melee
{
    public class Starclicker : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Clicker"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Makes four stars at the mouse cursor.");
        }

        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<ClickerDamage>(); ; // Makes our item use our custom damage type.
            Item.damage = 4;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = 260;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<ClickProjectile>(); ;
            Item.shootSpeed = 12.5f;
            Item.noMelee = true;


        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.GetModPlayer<Playe>().Clicks += 1;
            const int NumProjectiles = 0 ; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(66));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                if (player.direction == 1)
                {
                    Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                }
                if (player.direction == -1f)
                {
                    Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<ShadowflameSwordProjectile>(), damage - 5, knockback, player.whoAmI);
                }
                // Create a projectile.
               
            }
            if (player.GetModPlayer<Playe>().Clicks >= 4)
            {
                Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<LeftStar>(), damage * 2, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<RightStar>(), damage * 2, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<UpStar>(), damage * 2, knockback, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<DownStar>(), damage * 2, knockback, player.whoAmI);
                player.GetModPlayer<Playe>().Clicks = 0;
            }
            return true; // Return false because we don't want tModLoader to shoot projectile
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FallenStar, 51);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}