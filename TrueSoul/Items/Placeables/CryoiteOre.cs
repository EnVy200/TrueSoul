using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using TrueSoul.Projectiles.Tiles;
using IL.Terraria.WorldBuilding;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using TrueSoul.Items.Other;


namespace TrueSoul.Items.Placeables
{
    internal class CryoiteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 40;
            ItemID.Sets.SortingPriorityMaterials[Type] = 67;
            DisplayName.SetDefault("Corrupted Frigid Scrap");
        }





        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = 2700;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;







            Item.createTile = ModContent.TileType<CryiteOre>();





        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CryonicCore>(), 2);
            recipe.AddIngredient(ItemID.IceBlock, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }

}
	