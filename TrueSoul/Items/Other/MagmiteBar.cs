using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrueSoul.Items.Placeables;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Other
{
    public class MagmiteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magmite Bar"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A bar that requires hell to break it, literally.");
        }

        public override void SetDefaults()
        {

            Item.value = 3000;
            Item.rare = 3;
            Item.maxStack = 999;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MagmiteOre>(), 3);
            recipe.AddIngredient(ItemID.Obsidian, 3);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();

            Recipe HellstoneRecipe = CreateRecipe();
            HellstoneRecipe.AddIngredient(ModContent.ItemType<MagmiteOre>(), 1);
            HellstoneRecipe.AddTile(TileID.Hellforge);
            HellstoneRecipe.ReplaceResult(ItemID.Hellstone, 2);
            HellstoneRecipe.Register();


            Recipe Recipe = CreateRecipe();
            Recipe.AddIngredient(ItemID.HellstoneBar, 3);
            Recipe.AddTile(TileID.Hellforge);
            Recipe.Register();

            Recipe Recipe2 = CreateRecipe();
            Recipe2.AddIngredient(ItemID.Hellstone, 2);
            Recipe2.AddTile(TileID.Hellforge);
            Recipe2.ReplaceResult(ModContent.ItemType<MagmiteOre>(), 1);
            Recipe2.Register();
        }
    }
}