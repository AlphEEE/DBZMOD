using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Projectiles
{
    public class KaiokenAuraProj : ModProjectile
    {
        public float KaioAuraTimer;
        public float KaioSizeAddition;
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 95;
            projectile.height = 89;
            projectile.aiStyle = 0;
            projectile.alpha = 70;
            projectile.timeLeft = 10;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.damage = 0;
            KaioAuraTimer = 240;
            projectile.netUpdate = true;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.position.X = player.Center.X;
            projectile.position.Y = player.Center.Y;
            projectile.Center = player.Center + new Vector2(0, -25);
            MyPlayer MPlayer = new MyPlayer();
            if (!player.HasBuff(mod.BuffType("KaiokenBuff")))
            {
                projectile.Kill();
            }
            if(projectile.active)
            {
                Main.NewText("KaioAuraActive");
            }
            if (projectile.timeLeft < 2)
            {
                projectile.timeLeft = 10;
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }
            if (KaioAuraTimer > 0)
            {
                projectile.scale = 1f + KaioSizeAddition * (KaioAuraTimer / 240f);
                KaioAuraTimer--;
            }
            else
            {
                projectile.scale = 1f;
            }
            if (player.HasBuff(mod.BuffType("KaiokenBuffX100")))
            {
                KaioSizeAddition = 6f;
            }
            if (player.HasBuff(mod.BuffType("KaiokenBuffX20")))
            {
                KaioSizeAddition = 4f;
            }
            if (player.HasBuff(mod.BuffType("KaiokenBuffX10")))
            {
                KaioSizeAddition = 2.5f;
            }
            if (player.HasBuff(mod.BuffType("KaiokenBuffX3")))
            {
                KaioSizeAddition = 1.5f;
            }
            else
            {
                KaioSizeAddition = 1f;
            }
            
        }
    }
}