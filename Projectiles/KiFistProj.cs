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
			projectile.hide = true;
            projectile.width = 4;
            projectile.height = 4;
			projectile.aiStyle = 1;
			projectile.timeLeft = 10;
            projectile.ignoreWater = true;
			projectile.penetrate = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ki Punch");
        }
	}
}
