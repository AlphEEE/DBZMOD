using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
    public class FinalShine : ModItem
    {
        public override void SetDefaults()
        {

            item.magic = true;
            item.damage = 156;
            item.width = 28;
            item.height = 32;

            item.useTime = 47;
            item.useAnimation = 47;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = 10000000;
            item.rare = 10;
            item.mana = 56;
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("FinalShineProjectile");
            item.shootSpeed = 6f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Final Shine");
      Tooltip.SetDefault("Its Green, and Powerful.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FinalFlash");
			recipe.AddIngredient(null, "UKiGem" , 20);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}




