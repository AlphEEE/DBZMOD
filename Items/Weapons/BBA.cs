using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
    public class BBA : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 28;
            item.magic = true;
            item.width = 24;
            item.height = 28;

            item.useTime = 50;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 1000;
            item.rare = 2;
            item.mana = 13;
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("BBAProjectile");
            item.shootSpeed = 8f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Big Bang Attack");
      Tooltip.SetDefault("No Homo.");
    }

		  public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"VegetaScroll");
            recipe.AddIngredient(null,"KiGem", 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
