using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DBZMOD.Items
{
	public class KatchinHamaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 25;
			item.melee = true;
			item.width = 32;
			item.height = 32;

			item.useTime = 15;
			item.useAnimation = 15;
			item.axe = 70;
			item.hammer = 150;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Katchin Hamaxe");
      Tooltip.SetDefault("A Hamaxe Infused With Ki And Katchin.");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "KatchinBar" , 18);
			recipe.AddIngredient(null, "KiGem" , 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
