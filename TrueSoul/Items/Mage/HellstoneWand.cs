
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TrueSoul.Items.Mage
{
    public class HellstoneWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellstone Jab"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Casts three projectiles that break into weaker homing projectiles if it doesn't hit an enemy.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 88;
            Item.mana = 3;
            Item.DamageType = DamageClass.Magic;
            Item.width = 8;
            Item.height = 8;
            Item.useTime = 87;
            Item.useAnimation = 87;
            Item.useStyle = 5;
            Item.knockBack = 0;
            Item.value = 9000;
            Item.rare = 5;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CactusProjectile>();
            Item.shootSpeed = 12f;
            Item.noMelee = false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 3; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(25));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<StrongFireball>(), 62, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 23);
            recipe.AddIngredient(ItemID.Topaz, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}