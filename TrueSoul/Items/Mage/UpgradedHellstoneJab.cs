
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Other;

namespace TrueSoul.Items.Mage
{
    public class UpgradedHellstoneJab : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellstone Triple Jab"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Casts six projectiles that break into slightly weaker slow homing projectiles and if it doesn't still hit an enemy it will break into a weak extremely fast homing projectile.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 29;
            Item.mana = 3;
            Item.DamageType = DamageClass.Magic;
            Item.width = 8;
            Item.height = 8;
            Item.useTime = 115;
            Item.useAnimation = 115;
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
            const int NumProjectiles = 9; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(25));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<HellStrongFire>(), 29, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 23);
            recipe.AddIngredient(ModContent.ItemType<MagmiteBar>(), 22);
            recipe.AddIngredient(ModContent.ItemType<HellstoneWand>(), 1);
            recipe.AddIngredient(ItemID.OrichalcumBar, 32);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipeAlt = CreateRecipe();
            recipeAlt.AddIngredient(ItemID.HellstoneBar, 23);
            recipeAlt.AddIngredient(ModContent.ItemType<MagmiteBar>(), 22);
            recipeAlt.AddIngredient(ModContent.ItemType<HellstoneWand>(), 1);
            recipeAlt.AddIngredient(ItemID.MythrilBar, 32);
            recipeAlt.AddTile(TileID.MythrilAnvil);
            recipeAlt.Register();
        }
    }
}