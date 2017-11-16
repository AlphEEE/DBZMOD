using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DBZMOD.Items.Weapons
{
	public class KatchinBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 25;
			item.ranged = true;
			item.width = 18;
			item.height = 36;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 1;
			item.shootSpeed = 5f;
			item.useAmmo = AmmoID.Arrow;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Katchin Bow");
      Tooltip.SetDefault("A Bow Infused With Ki And Katchin.");
    }

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "KatchinBar", 20);
            recipe.AddIngredient(null, "KiGem", 27);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
