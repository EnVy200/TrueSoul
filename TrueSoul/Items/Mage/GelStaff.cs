using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrueSoul.Items.Ranged;

namespace TrueSoul.Items.Mage
{
    public class GelStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gel Staff"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("I give up, here's the description 'Casts a bouncy slimeball with lots of knockback at enemies.'THERE, is THAT good?");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 36;
            Item.mana = 11;
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 5;
            Item.knockBack = 10;
            Item.value = 10000;
            Item.rare = 3;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<MagicSlimeball>();
            Item.shootSpeed = 3f;
            Item.noMelee = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 25);
            recipe.AddIngredient(ItemID.Ruby, 10);
            recipe.AddIngredient(ItemID.Wood, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}