using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class KiGem : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 28;
            item.height = 24;
            item.value = 100;
            item.maxStack = 99;
            item.rare = 2;
			item.scale = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ki Gem");
      Tooltip.SetDefault("A Crystal of Pure Essence.");
    }
     public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "UnrefinedKiGem", 1);
            recipe.AddIngredient(null, "UnrefinedKiGem", 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
