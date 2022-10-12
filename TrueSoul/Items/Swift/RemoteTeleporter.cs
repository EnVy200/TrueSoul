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
    public class RemoteTeleporter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Remote Teleporter"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Make a teleport location with left click and teleport with right click.");
        }

        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<SwiftDamage>(); ;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = 1;
            Item.knockBack = 18;
            Item.value = 260;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<TeleportProjectile>();
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Mod.Logger.Error("Test");

            if (player.altFunctionUse == 2)
            {
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    Projectile proj = Main.projectile[i];
                    if(proj.type == ModContent.ProjectileType<TeleportProjectile>())
                    {
                        player.Teleport(proj.Center, TeleportationStyleID.TeleportationPotion);

                        
                    }
                }


                  
                return false;
            }
            else
            {
                
              
                return true;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            player.velocity.X = player.oldVelocity.X = 0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood");
            recipe.AddIngredient(ItemID.RodofDiscord);
            recipe.AddIngredient(ItemID.PlatinumCoin, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}