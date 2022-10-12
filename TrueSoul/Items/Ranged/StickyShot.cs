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
    public class StickyShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sticky Shot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("This sticky abomination shoots EXTREMELY fast."); CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        Random rnd = new Random();
        public override void SetDefaults()
        {
            Item.damage = 29;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 53;
            Item.useAnimation = 53;
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


            int NumProjectiles = Main.rand.Next(3, 6);//3, 4, or 5

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<GelProjectile>(), 98, knockback, player.whoAmI);
            return false; // Return false because we don't want tModLoader to shoot projectile
        }



        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 999);
            recipe.AddIngredient(ItemID.FlintlockPistol);
            recipe.AddIngredient(ItemID.HellstoneBar, 32);
            recipe.AddIngredient(ItemID.IllegalGunParts, 2);
            recipe.AddIngredient(ItemID.HallowedBar, 18);
            recipe.AddIngredient(ItemID.Minishark, 2);
            recipe.AddIngredient(ItemID.Megashark, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}