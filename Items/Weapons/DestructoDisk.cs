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
	public class DestructoDisk : KiItem
	{
        private Player player;

        public override void SetDefaults()
		{
			item.shoot = mod.ProjectileType("DestructoDiskProjectile");
			item.shootSpeed = 40f;
			item.damage = 50;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 25;
			item.useTime = 28;
			item.width = 20;
			item.noUseGraphic = true;
			item.height = 20;
			item.autoReuse = false;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 1;
	    }
		public override bool UseItem(Player player)
        {
            MyPlayer.ModPlayer(player).KiControlStat += 1;
            return true;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
	        recipe.AddIngredient(3);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
	        recipe.AddRecipe();
		}
	}
}