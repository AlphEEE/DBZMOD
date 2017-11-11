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
	public class BigBangAttack : KiItem
	{
		public override void SetDefaults()
		{
			item.shoot = mod.ProjectileType("BigBangAttackProjectile");
			item.shootSpeed = 25f;
			item.damage = 95;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 25;
			item.useTime = 30;
			item.width = 40;
			item.noUseGraphic = true;
			item.height = 40;
			item.autoReuse = false;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 3;
	    }
        public override bool UseItem(Player player)
        {
            MyPlayer.ModPlayer(player).KiControlStat += 1;
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 58f;
			if (Collision.CanHit(position, 1, 1, position + muzzleOffset, 1, 1))
			{
				position += muzzleOffset;
			}
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