using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class EKiGem : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 14;
            item.height = 14;
            item.value = 100;
            item.maxStack = 99;
            item.rare = 5;
	    item.scale = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Empowered Ki Gem");
      Tooltip.SetDefault("Empowered With The Might Of Terraria.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "KatchinBar" , 2);
	    recipe.AddIngredient(1006 , 2);
	    recipe.AddIngredient(null, "KiGem" , 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
