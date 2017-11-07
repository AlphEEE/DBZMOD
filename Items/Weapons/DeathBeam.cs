using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
	public class DeathBeam : ModItem
	{
		public override void SetDefaults()
		{

			item.magic = true;
			item.damage = 40;

			item.width = 28;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 8;
			item.value = 500000;
			item.rare = 3;
			item.mana = 25;
			item.UseSound = SoundID.Item21;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType ("DeathBeamProjectile");
			item.shootSpeed = 8f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Death Beam");
      Tooltip.SetDefault("Takes About 10 Episodes Before It Hits Something.");
    }

	}
}
