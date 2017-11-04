using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DBZMOD.Items.Weapons
{
    public class Masenko : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 25;
            item.magic = true;
            item.width = 24;
            item.height = 28;

            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 1000;
            item.rare = 2;
            item.mana = 14;
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("MasenkoProjectile");
            item.shootSpeed = 8f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Masenko");
      Tooltip.SetDefault("SLUG BEAM!!");
    }

		  public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"PiccoloScroll");
            recipe.AddIngredient(null,"KiGem", 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
