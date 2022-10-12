using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace TrueSoul.Items.Ranged
{
    public class ShotDynamite : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diamond Bolt"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

        }

        public override void SetDefaults()
        {
            //Projectile.magic = true;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 250;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 10000;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.ArmorPenetration = 15;
        }
        int Timer = 0;
        
  


        public override void AI()
        {
            if (Timer <= 5)
            {
                Projectile.velocity.X = 0;
                Projectile.velocity.Y = 0;
            }



            Timer++;
            if (Timer <= 20)
            {
                Projectile.velocity.X = 0;
                Projectile.velocity.Y -= 0.7f;
            }
            if (Timer >= 20)
            {

            }

            if (Timer >= 40)
            {
                Projectile.Kill();
                const int NumProjectiles = 10; // The humber of projectiles that this gun will shoot.

                for (int i = 0; i < NumProjectiles; i++)
                {
                    // Rotate the velocity randomly by 30 degrees at max.
                    Vector2 newVelocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));

                    // Decrease velocity randomly for nicer visuals.


                    // Create a projectile.




                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, newVelocity, ModContent.ProjectileType<Spark>(), 36, 1, Main.myPlayer);


                }
                const int NumProjectiles2 = 6;
                for (int i = 0; i < NumProjectiles2; i++)
                {
                    // Rotate the velocity randomly by 30 degrees at max.
                    Vector2 newVelocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));

                    // Decrease velocity randomly for nicer visuals.


                    // Create a projectile.




                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, newVelocity, ModContent.ProjectileType<HomingSpark>(), 80, 1, Main.myPlayer);


                }
                Projectile.velocity.Y += 0.1f;
            }

                


               
                   

                   
                }
            
            }

           
        }





    

