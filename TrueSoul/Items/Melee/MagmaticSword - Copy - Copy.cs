using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Other;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Melee
{
    public class ShadowflameSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Shoots 25 shadowflame bullets which curve backwards.");
        }

        public override void SetDefaults()
        {
            Item.damage = 55;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 250;
            Item.useAnimation = 250;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = 260;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ShadowflameSwordProjectile2>(); ;
            Item.shootSpeed = 12.5f;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 200; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(66));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                if (player.direction == 1)
                {
                    Projectile.NewProjectileDirect(source, position, newVelocity, type, damage - 50, knockback, player.whoAmI);
                }
                if (player.direction == -1f)
                {
                    Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<ShadowflameSwordProjectile>(), damage - 50, knockback, player.whoAmI);
                }
                // Create a projectile.
               
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObamaSword>(), 66);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}