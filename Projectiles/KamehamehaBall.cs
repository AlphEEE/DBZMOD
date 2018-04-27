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
	public class KamehamehaBall : KiProjectile
	{
        private Player player;
		public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.friendly = true;
			projectile.tileCollide = false;
            projectile.width = 80;
            projectile.height = 80;
			projectile.aiStyle = 1;
			projectile.light = 1f;
            projectile.timeLeft = 10;
            projectile.netUpdate = true;
            projectile.damage = 0;
			aiType = 14;
            projectile.ignoreWater = true;
			projectile.penetrate = -1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("KamehamehaBall");
        }
   
        public override void AI()
        {
            if(projectile.timeLeft < 4)
            {
                projectile.timeLeft = 10;
            }
            Player player = Main.player[projectile.owner];
            projectile.position.X = player.Center.X;
            projectile.position.Y = player.Center.Y;

            if (!player.channel && ChargeLevel < 1)
            {
                projectile.Kill();
            }
            if (player.channel && projectile.active)
            {
                ChargeTimer++;
                KiDrainTimer++;
            }
            if(ChargeTimer > 60)
            {
                ChargeLevel += 1;
                ChargeTimer = 0;
            }
            if(!player.channel && ChargeLevel > 1)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.Center.X - Main.MouseWorld.X, projectile.Center.Y - Main.MouseWorld.Y, mod.ProjectileType("KamehamehaBlast"), projectile.damage + (ChargeLevel * 20), 4f, projectile.owner, 0, projectile.rotation);
                ChargeLevel = 0;
            }

            if (KiDrainTimer > 3 && MyPlayer.ModPlayer(player).KiCurrent >= 0)
            {
                MyPlayer.ModPlayer(player).KiCurrent -= 1;
                KiDrainTimer = 0;
            }
        }

	}
}