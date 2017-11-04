using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
 
namespace DBZMOD.Mounts
{
    public class NimbusMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = 10;
            mountData.buff = mod.BuffType("NimbusBuff");
            mountData.heightBoost = 10;          //how high is the mount from the ground
            mountData.fallDamage = 0f;
            mountData.runSpeed = 11f;
            mountData.dashSpeed = 11f;
            mountData.flightTimeMax = 100000;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 7;
            mountData.acceleration = 0.30f;
            mountData.jumpSpeed = 7f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 12;            //mount frame/animation
            mountData.constantJump = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 1;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = -10;                    
            mountData.yOffset = 50;          //how high is the mount from the player
            mountData.bodyFrame = 3;          //player frame when it's on the mount
            mountData.playerHeadOffset = 10;        
            mountData.standingFrameCount = 12;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 12;
            mountData.runningFrameDelay = 12;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 12;
            mountData.flyingFrameDelay = 12;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 12;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 12;
            mountData.idleFrameDelay = 12;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.frontTexture.Width;
                mountData.textureHeight = mountData.frontTexture.Height;
            }
        }
 
        public override void UpdateEffects(Player player)
        {
            if (Math.Abs(player.velocity.X) > 4f)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, 10);
            }
        }
    }
}