using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.DamageClasses;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Other;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Melee
{
    public class SnowyClicker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosty Clicker"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Click enemies to do damage, and clicking inflicts frostflame and cursed inferno.");
        }

        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.DamageType = ModContent.GetInstance<ClickerDamage>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 3;
            Item.useAnimation = 3;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = 260;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<ShadowflameSwordProjectile2>(); 
            Item.shootSpeed = 12.5f;
            Item.noMelee = true;
           

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
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
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<IcyClickProjectile>(), damage, knockback, player.whoAmI);
            return false; // Return false because we don't want tModLoader to shoot projectile
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CryoiteBar>(), 22);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();



        }
    }
}