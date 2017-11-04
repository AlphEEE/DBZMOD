using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
	public class LightGrenade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 75;
			item.magic = true;
			item.width = 28;
			item.height = 32;

			item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true; 
            item.knockBack = 2;        
            item.value = 100000;
            item.rare = 5;
            item.mana = 20;         
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType 
                ("LightGrenadeProjectile");
            item.shootSpeed = 8f;
			
			
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Light Grenade");
      Tooltip.SetDefault("I Dunno What to put here.");
    }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"Masenko");
            recipe.AddIngredient(null,"EKiGem", 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
