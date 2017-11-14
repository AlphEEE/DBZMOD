using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items
{
	public class KatchinBar : ModItem
	{
		public override void SetDefaults()
		{


			item.width = 30;
            item.height = 24;
			item.value = 100000;
			item.maxStack = 999;
			item.rare = 5;
			
		}	

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Katchin Bar");
      Tooltip.SetDefault("This Looks Incredibly Durable!");
    }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "KatchinShard", 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }		
	}
}
