using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace DBZMOD.Items
{
    public class EmptyScroll : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 36;
            item.height = 36;
            item.value = -1;
            item.rare = 1;
            
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Empty Scroll");
      Tooltip.SetDefault("An Empty Piece of Parchment, I Wonder What I Can Craft it Into?");
    }

    }
}
