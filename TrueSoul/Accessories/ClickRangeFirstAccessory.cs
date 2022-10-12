using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Other;
using TrueSoul.DamageClasses;

namespace TrueSoul.Accessories
{
    public class ClickRangeFirstAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gel Click Sentinel"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Increases click damage by 3.");
        }

        public override void SetDefaults()
        {
            Item.width = 60;
            Item.height = 60;
            Item.value = 260;
            Item.rare = 3;
            Item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<Playe>().ClickAOEAdd += 3;
        }
           
        
           
        

        public override void AddRecipes()
        {

        }
    }
}