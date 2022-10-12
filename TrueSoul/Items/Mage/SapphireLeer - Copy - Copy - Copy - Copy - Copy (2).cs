
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Other;

namespace TrueSoul.Items.Mage
{
    public class ObamaCircle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obama Circle"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("OBAMA CARE!");
            Item.staff[Item.type] = true;
        }


        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.mana = 7;
            Item.DamageType = DamageClass.Magic;
            Item.width = 8;
            Item.height = 8;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = 5;
            Item.knockBack = 0;
            Item.value = 9000;
            Item.rare = 5;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ObamiumProjectile>();
            Item.shootSpeed = 12f;
            Item.noMelee = false;
            Item.ArmorPenetration = 255;

        }

 
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(360));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<ObamiumProjectile>(), 100, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Obamium>(), 75);
            recipe.Register();

        }
    }
}