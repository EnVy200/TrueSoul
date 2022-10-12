using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using TrueSoul.Projectiles.Tiles;



namespace TrueSoul.Items.Placeables
{
    internal class MagmiteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 40;
            ItemID.Sets.SortingPriorityMaterials[Type] = 58;
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







            Item.createTile = ModContent.TileType<MagmaiteOre>();

            



        }
    }
}
