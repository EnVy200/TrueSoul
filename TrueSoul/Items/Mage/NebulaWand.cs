using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace TrueSoul.Items.Mage
{
    public class NebulaWand : ModItem
    {
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Wand"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A powerful wand that casts a nebula beam.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 140;
            Item.mana = 6;
            Item.DamageType = DamageClass.Magic;
            Item.width = 8;
            Item.height = 8;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.useStyle = 5;
            Item.knockBack = 0;
            Item.value = 900000;
            Item.rare = 3;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<NebulaBeam>();
            Item.shootSpeed = 19f;
            Item.noMelee = true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.NebulaArcanum);
            recipe.AddIngredient(ItemID.Wood, 150);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}