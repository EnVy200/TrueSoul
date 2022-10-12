using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Tools
{
    public class StoneAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Hamaxe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("MINECRAFT?!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 2;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 9;
            Item.value = 267;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.hammer = 26;
            Item.axe = 15;
            Item.useTurn = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 22);
            recipe.AddIngredient(ItemID.Wood, 68);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}