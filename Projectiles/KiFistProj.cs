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
	public class KiFistProj : KiProjectile
	{
		public override void SetDefaults()
        {
            projectile.hostile = false;
            projectile.friendly = true;
			projectile.tileCollide = false;
            projectile.width = 6;
            projectile.height = 6;
			projectile.aiStyle = 1;
			projectile.light = 1f;
			projectile.timeLeft = 20;
            projectile.ignoreWater = true;
			projectile.penetrate = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ki Punch");
        }
	}
}