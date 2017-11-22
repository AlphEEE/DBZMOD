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
			item.useAnimation = 6;
			item.useTime = 6;
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

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X + 5, position.Y, speedX, speedY, mod.ProjectileType("KiFistProj"), damage, knockBack, player.whoAmI);
            return false;
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
