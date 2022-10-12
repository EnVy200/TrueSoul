using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrueSoul.Items.Placeables;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;


namespace TrueSoul.Items.Other
{
    public class CryoiteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            if (!WorldGen.crimson)
            {
                DisplayName.SetDefault("Corrupted Frigid Plating");
                Tooltip.SetDefault("Your finger feels like ice when touching this... It crumbles under your finger...");
            }
            if (WorldGen.crimson)
            {
                DisplayName.SetDefault("Crimson Frigid Plating");
                Tooltip.SetDefault("Your finger feels like ice when touching this... It seems like it's watching you...");
            }
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 19));
        }

        public override void SetDefaults()
        {

            Item.value = 6500;
            Item.rare = 5;
            Item.maxStack = 999;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CryoiteOre>(), 4);
            recipe.AddIngredient(ItemID.SnowBlock, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}