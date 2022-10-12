using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Ranged
{
    public class Mayhem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mayhem"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Infinite power, infinite possibility."); CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }


        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 0;
            Item.useAnimation = 5;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 3;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 25f;
            Item.noMelee = true;
            Item.ArmorPenetration = 1000000;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {


            const int NumProjectiles = 3;

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(3.9f));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            Projectile.NewProjectileDirect(source, position, velocity, ProjectileID.CursedFlameFriendly, 60, knockback, player.whoAmI);
            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 160);
            recipe.AddIngredient(ModContent.ItemType<GelMiniBow>());
            recipe.AddIngredient(ModContent.ItemType<GelTriBow>());
            recipe.AddIngredient(ModContent.ItemType<GelBow>());
            recipe.AddIngredient(ItemID.LunarBar, 14);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            recipe.AddIngredient(ItemID.HallowedBar, 14);
            recipe.AddIngredient(ItemID.SpectreBar, 14);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}