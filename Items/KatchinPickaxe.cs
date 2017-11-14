using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DBZMOD.Items
{
	public class KatchinPickaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.melee = true;
			item.width = 38;
			item.height = 38;

			item.useTime = 12;
			item.useAnimation = 12;
			item.pick = 100;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Katchin Pickaxe");
      Tooltip.SetDefault("You'd Think It'd Be Heavy, But Screw Physics, its Dragon Ball Z!");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "KatchinBar", 12);
			recipe.AddIngredient(null, "KiGem", 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
