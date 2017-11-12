using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Projectiles
{
	public class BigBangAttackProjectile : KiProjectile
	{
		public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SwordBeam);
            projectile.hostile = false;
            projectile.friendly = true;
			projectile.tileCollide = false;
            projectile.width = 68;
            projectile.height = 92;
			projectile.aiStyle = 1;
			projectile.light = 1f;
			aiType = 14;
            projectile.ignoreWater = true;
			projectile.penetrate = 4;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BigBangAttackProjectile");
        }
		
        public override bool PreAI()
        {
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.ai[1] = 0f;
                projectile.alpha = 255;

                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 22;
                projectile.height = 22;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.knockBack = 8f;
            }
            return true;
        }

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
		    return true;
		}
   
        public override void AI()
        {
			 projectile.ai[1]++;
            if(projectile.ai[1] == 4)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 0, 2, 0, mod.ProjectileType("BigBangAttackTrail"), projectile.damage, 4f, projectile.owner);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 0, 2, 0, mod.ProjectileType("BigBangAttackTrail"), projectile.damage, 4f, projectile.owner);
                projectile.ai[1] = 0;
            }
        }
	}
}