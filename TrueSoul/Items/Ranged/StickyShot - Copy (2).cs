using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using TrueSoul.Items.Ranged;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework.Graphics;
using TrueSoul.Items.Other;

namespace TrueSoul.Items.Ranged
{
    public class TheSpark : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Spark"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Fires a spark. Also fires a stick of dynamite with right click that explodes into lots of projectiles."); CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        Random rnd = new Random();
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 5;
            Item.knockBack = 2f;
            Item.value = 5000;
            Item.rare = 8;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 30f;
            Item.noMelee = true;

        }
        int DynaDamage = 0;

        public override void UseAnimation(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 21;
                Item.useAnimation = 21;
                
                Item.useStyle = 1;
                Item.autoReuse = false;

            }
            if (player.altFunctionUse != 2)
            {
                Item.useTime = 4;
                Item.useAnimation = 4;
                Item.alpha = 0;
                Item.useStyle = 5;
                Item.autoReuse = true;

            }
            base.UseAnimation(player);
        }
        public override bool? UseItem(Player player)
        {

            return base.UseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            return base.PreDrawInInventory(spriteBatch, position, frame, drawColor, itemColor, origin, scale);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {


            int NumProjectiles = 1;


            for (int i = 0; i < NumProjectiles; i++)
            {
                if (player.altFunctionUse == 2)
                {
                    
                    Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<ShotDynamite>(), damage * DynaDamage, knockback, player.whoAmI);
                    return false;
                    Item.alpha = 0;
                }
                else
                {

                    // Rotate the velocity randomly by 30 degrees at max.
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(27));

                    // Decrease velocity randomly for nicer visuals.
                    newVelocity *= 1f - Main.rand.NextFloat(0.5f);

                    // Create a projectile.
                    Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Spark>(), damage, knockback, player.whoAmI);
                }


            }

         
            return false; // Return false because we don't want tModLoader to shoot projectile
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MagmiteBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<CryoiteBar>(), 21);

            recipe.AddIngredient(ModContent.ItemType<StarlightBar>(), 31);
            recipe.AddIngredient(ItemID.Dynamite, 99);
            recipe.AddIngredient(ItemID.HellstoneBar, 17);
            
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}