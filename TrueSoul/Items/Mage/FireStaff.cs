using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Items.Other;
using TrueSoul.Items.Melee;

namespace TrueSoul.Items.Mage
{
    public class FireStaff : ModItem
    {
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Staff"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Casts a fireball at enemies.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.ArmorPenetration = 9999999;
            Item.mana = 3;
            Item.DamageType = DamageClass.Magic;
            Item.width = 8;
            Item.height = 8;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = 5;
            Item.knockBack = 5;
            Item.value = 9000;
            Item.rare = 3;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<FireballProjectile>();
            Item.shootSpeed = 4.5f;
            Item.noMelee = false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MagmiteBar>(), 22);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}