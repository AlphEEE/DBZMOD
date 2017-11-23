using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Slimymod.Items
{
	public class Gelikite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gelikite");
			Tooltip.SetDefault("This gel is rock hard!");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"GelikiteChunk", 4);
			recipe.AddIngredient(ItemID.HellstoneBar, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 1);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}