using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class PiccoloScroll : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 36;
            item.height = 36;
            item.value = 0;
            item.rare = 1;
            
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Piccolo Scroll");
      Tooltip.SetDefault("The Scroll of a Tactician");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EmptyScroll");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
