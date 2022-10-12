using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TrueSoul.Items.Mage;
using TrueSoul.Items.Other;
using TrueSoul.DamageClasses;
using Terraria.GameContent.Creative;

namespace TrueSoul.Items.Swift
{
    public class WhitePhaseSagi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Phase Sagi"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A sagi made out of gems, and meteorite.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 27;
            Item.DamageType = ModContent.GetInstance<SwiftDamage>(); ;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 27;
            Item.useAnimation = 27;
            Item.useStyle = 3;
            Item.knockBack = 18;
            Item.value = 260;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shootSpeed = 12.5f;

        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }

        public override bool? UseItem(Player player)
        {
            player.velocity.X = player.direction * 6f;
            return base.UseItem(player);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            player.velocity.X = player.oldVelocity.X = 0f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Diamond, 10);
            recipe.AddIngredient(ItemID.MeteoriteBar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}