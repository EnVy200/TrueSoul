using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Items.Ranged;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Ranged
{
    public class OnyxCannonBetter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Onyx Cannon.. But Better"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Shoots medium speed and two projectiles that go toward the player and pass them by, it shoots the onyx projectile as well. Does HIGH DAMAGE"); CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        Random rnd = new Random();
        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = 5;
            Item.knockBack = 2f;
            Item.value = 5000;
            Item.rare = 8;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 8f;
            Item.noMelee = true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }
       
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1;
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<ElectricBolt1>(), damage, knockback, player.whoAmI);
            }

            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<FluctiationProjectile>(), damage + 60, knockback, player.whoAmI);
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<SpectralProjectile>(), damage + 60, knockback, player.whoAmI);
            Projectile.NewProjectileDirect(source, position, velocity, ProjectileID.BlackBolt, damage * 15, knockback, player.whoAmI);
            return false; // Return false because we don't want tModLoader to shoot projectile
        }



        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 45);
            recipe.AddIngredient(ModContent.ItemType<OnyxCannon>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}