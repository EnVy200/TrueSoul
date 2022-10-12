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
    public class IcySagi : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostflame Sagi"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Right click to throw a projectile which adds the frostflame and slowness debuffs to an enemy.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.DamageType = ModContent.GetInstance<SwiftDamage>(); ;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = 3;
            Item.knockBack = 18;
            Item.value = 260;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.shoot = Item.shoot = ModContent.ProjectileType<IcyProjectile>();
            Item.autoReuse = false;
            Item.shootSpeed = 12.5f;

            
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                return base.UseItem(player);
                player.velocity.X = player.direction * 1f;
            }
            else
            {
                player.velocity.X = player.direction * 8f;
                return base.UseItem(player);
            }
            
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<IcyProjectile>(), damage - 8, knockback, player.whoAmI);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            player.velocity.X = player.oldVelocity.X = 0f;
        }
        public override void AddRecipes()
        {

        }
    }
}