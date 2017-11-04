using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
    public class UKiGem : ModItem
    {
        public override void SetDefaults()
        {


            item.width = 14;
            item.height = 14;
            item.value = 100;
            item.maxStack = 99;
            item.rare = 10;
			item.scale = 2;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ultimate Ki Gem");
      Tooltip.SetDefault("A Piece Of The Moon Lord's Soul Rests In This Gem.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3460 , 2);
			recipe.AddIngredient(null, "EKiGem" , 1);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
