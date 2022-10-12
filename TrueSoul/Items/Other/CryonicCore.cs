using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrueSoul.Items.Placeables;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Other
{
    public class CryonicCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icy Heart"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A crystal dropped from icy enemies.");
        }

        public override void SetDefaults()
        {

            Item.value = 900;
            Item.rare = 3;
            Item.maxStack = 999;

        }

        public override void AddRecipes()
        {
            

        }
    }
}