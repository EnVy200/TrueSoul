using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.TrueMelee
{
    public class InstakillSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A sword.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 999999999;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 2;
            Item.useAnimation = 2;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 260;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {

        }
    }
}