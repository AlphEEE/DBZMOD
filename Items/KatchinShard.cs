using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
	public class KatchinShard : ModItem
	{
		public override void SetDefaults()
		{


			item.width = 15;
            item.height = 15;
			item.value = 10000;
			item.maxStack = 999;
			item.rare = 5;
			
		}				

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Katchin Shard");
      Tooltip.SetDefault("Seems Like A Very Tough Material.");
    }

	}
}
