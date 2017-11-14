using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
	public class SenzuBean : ModItem
	{
		public override void SetDefaults()
		{


			item.width = 40;
			item.height = 40;
			item.healLife = 9001;
			item.consumable = true;
			item.maxStack = 99;
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.value = 10000;
			item.rare = 3;
			item.potion = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Senzu Bean");
      Tooltip.SetDefault("Fully Heals Health.");
    }

	}
}
