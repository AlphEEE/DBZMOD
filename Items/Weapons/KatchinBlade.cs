using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DBZMOD.Items.Weapons
{
	public class KatchinBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 38;
			item.melee = true;
			item.width = 52;
			item.height = 52;

			item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1; 
            item.knockBack = 5;        
            item.value = 1000000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Katchin Blade");
      Tooltip.SetDefault("A Blade Of Infused Ki And Katchin.");
    }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "KatchinBar", 20);
            recipe.AddIngredient(null, "KiGem", 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
