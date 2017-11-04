using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
    public class Mankankosappo : ModItem
    {
        public override void SetDefaults()
        {

            item.magic = true;
            item.damage = 143;
            item.width = 28;
            item.height = 32;
            item.useTime = 37;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = 10000000;
            item.rare = 10;
            item.mana = 41;
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("SBCProjectile");
            item.shootSpeed = 6f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mankankosappo");
      Tooltip.SetDefault("Mankaosppe...Mankwankoppo..Ah to hell with it...SPECIAL BEAM CANNON!");
    }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LightGrenade");
			recipe.AddIngredient(null, "UKiGem" , 20);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}




