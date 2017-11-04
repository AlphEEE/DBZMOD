using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
	public class FinalFlash : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 68;
			item.magic = true;
			item.width = 28;
			item.height = 32;

			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 8;
			item.value = 10000000;
			item.rare = 7;
			item.mana = 32;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType ("FinalFlashProjectile");
			item.shootSpeed =6f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Final Flash");
      Tooltip.SetDefault("The Visualization of Pride!");
    }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"BBA");
            recipe.AddIngredient(null,"EKiGem", 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
