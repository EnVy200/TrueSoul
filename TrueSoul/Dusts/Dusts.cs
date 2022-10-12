﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;



namespace TrueSoul.Dusts
{
    public class ExplosionDust : ModDust
    {
        int speed = 1;
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= Vector2.UnitX.RotatedByRandom(MathHelper.Pi) * speed; // Multiply the dust's start velocity by 0.4, slowing it down
            dust.noGravity = true; // Makes the dust have no gravity.
            dust.noLight = false; // Makes the dust emit no light.
            dust.scale *= 1.5f; // Multiplies the dust's initial scale by 1.5.
            
        }

        public override bool Update(Dust dust)
        { // Calls every frame the dust is active
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.90f;

            float light = 1f * dust.scale;

            Lighting.AddLight(dust.position, light, light, light);

            if (dust.scale < 0.4f)
            {
                dust.active = false;
            }

            return false; // Return false to prevent vanilla behavior.
        }
    }

    public class RedSparkleAllDir : ModDust
    {
        int speed = 1;
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= Vector2.UnitX.RotatedByRandom(MathHelper.Pi) * speed; // Multiply the dust's start velocity by 0.4, slowing it down
            dust.noGravity = true; // Makes the dust have no gravity.
            dust.noLight = false; // Makes the dust emit no light.
            dust.scale *= 3f; // Multiplies the dust's initial scale by 1.5.

        }

        public override bool Update(Dust dust)
        { // Calls every frame the dust is active
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;

            float light = 1f * dust.scale;

            Lighting.AddLight(dust.position, light, light, light);

            if (dust.scale < 0.4f)
            {
                dust.active = false;
            }

            return false; // Return false to prevent vanilla behavior.
        }
    }
}
    
        
    
    

 

