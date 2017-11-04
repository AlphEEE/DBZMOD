using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
    public class Kamehameha : ModItem
    {
        public override void SetDefaults()
        {

             item.damage = 30;
             item.magic = true;
             item.width = 24;
             item.height = 28;
			item.channel = true;
             item.useTime = 30;
             item.useAnimation = 30;
             item.useStyle = 5;
            item.noMelee = true; 
            item.knockBack = 2;        
            item.value = 1000;
            item.rare = 2;
            item.mana = 10;         
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("KamehamehaProjectile");
            item.shootSpeed = 8f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Kamehameha");
      Tooltip.SetDefault("The Signature Move");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"GokuScroll");
            recipe.AddIngredient(null,"KiGem", 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
