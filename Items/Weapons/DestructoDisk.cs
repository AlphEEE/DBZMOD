using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
	public class DestructoDisk : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 50;
			item.magic = true;
			item.width = 28;
			item.height = 32;

			item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true; 
            item.knockBack = 0;        
            item.value = 100000;
            item.rare = 5;
            item.mana = 30;         
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType 
                ("KienzanProjectile");
            item.shootSpeed = 5f;
			
			
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Kienzan(WIP NOT FINISHED)");
      Tooltip.SetDefault("Its a Frisbee, I swear.");
    }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(175, 20);
            recipe.AddIngredient(null,"KiGem", 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
