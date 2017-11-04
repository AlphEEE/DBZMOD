using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class UnrefinedKiGem : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 24;
            item.value = 100;
            item.maxStack = 990;
            item.rare = 2;
			item.scale = 1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ki Gem");
      Tooltip.SetDefault("A fragment of unimaginable power.");
    }

    }
}
