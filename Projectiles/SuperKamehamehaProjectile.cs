using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Projectiles
{
	public class SuperKamehamehaProjectile : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Kamehameha");
        }
        public override void SetDefaults()
		{
			projectile.width = 840;
			projectile.height = 840;
            projectile.friendly = true;
            projectile.penetrate = -1;                       
            Main.projFrames[projectile.type] = 1;           
            projectile.hostile = false;
			projectile.magic = true;                        
            projectile.tileCollide = false;                 
			projectile.ignoreWater = true;
	    projectile.scale = 3f;
		}
				public override void AI()
		{   
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
			projectile.alpha = (int)projectile.localAI[0] * 2;
			
			if (projectile.localAI[0] > 130f)
            {
				projectile.Kill();
			}
		}
	}
}