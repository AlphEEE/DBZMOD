using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class VegetaScroll : ModItem
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
      DisplayName.SetDefault("Vegeta Scroll");
      Tooltip.SetDefault("A Scroll Filled With Pure Pride!");
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
