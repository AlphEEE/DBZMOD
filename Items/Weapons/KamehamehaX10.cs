using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
    public class KamehamehaX10 : ModItem
    {
        public override void SetDefaults()
        {

            item.magic = true;
            item.damage = 150;
            item.width = 28;
            item.height = 32;

            item.useTime = 47;
            item.useAnimation = 47;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = 10000000;
            item.rare = 10;
            item.mana = 51;
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("KamehamehaX10Projectile");
            item.shootSpeed = 6f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Kamehameha X10");
      Tooltip.SetDefault("Doesnt make much sense, but its cool.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SuperKamehameha");
			recipe.AddIngredient(null, "UKiGem" , 20);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}




