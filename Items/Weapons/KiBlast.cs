using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
    public class KiBlast : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 15;
            item.thrown = true;
            item.noMelee = true;
            item.width = 28;
            item.height = 32;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 1000;
            item.rare = 1;
            item.reuseDelay = 15;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("KiBlastProjectile");
            item.shootSpeed = 8f;
            item.useTurn = true;
            item.noUseGraphic = true;		
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ki Blast");
      Tooltip.SetDefault("A Basic Ki Attack.");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "UnrefinedKiGem", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
