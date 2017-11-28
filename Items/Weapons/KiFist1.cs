using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
	public class KiFist1 : KiItem
	{
		public override void SetDefaults()
		{
			item.shoot = mod.ProjectileType("KiFistProj");
			item.shootSpeed = 0f;
			item.damage = 15;
			item.knockBack = 5f;
			item.useStyle = 3;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 5;
			item.useTime = 1;
			item.width = 12;
			item.noUseGraphic = true;
			item.height = 12;
			item.autoReuse = false;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 2;
	    }
	    public override void SetStaticDefaults()
		{
		Tooltip.SetDefault("-Tier 1-");
		DisplayName.SetDefault("Ki Fist");
		}


        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
	        recipe.AddIngredient(null, "StableKiCrystal", 20);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
	        recipe.AddRecipe();
		}
	}
}
